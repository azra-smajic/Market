-- DROP FUNCTION public.fn_products_get_by_parameters(text, text, uuid, uuid, int4, int4);

CREATE OR REPLACE FUNCTION public.fn_products_get_by_parameters("pName" text, "pSku" text, "pMarketId" uuid, "pProductCategoryId" uuid, "pLimit" integer, "pOffset" integer)
 RETURNS TABLE("Id" uuid, "Name" text, "Sku" text, "MarketId" uuid, "ProductCategoryId" uuid, "ProductCategoryName" text, "Price" numeric, "Currency" text, "Discount" numeric, "TaxRate" numeric, "Status" text, "TotalRecordsCount" integer)
 LANGUAGE plpgsql
AS $function$
BEGIN	
	RETURN QUERY 
	SELECT "P"."Id", 
		   "P"."Name",
		   "P"."Sku",
		   "P"."MarketId",
		   "P"."ProductCategoryId",
		   "PC"."Name",
		   "P"."Price",
		   "P"."Currency",
		   "P"."Discount",
		   "P"."TaxRate",
		   "P"."Status",
		   (COUNT(*) OVER())::integer AS "TotalRecordsCount"
	FROM "Products" AS "P" INNER JOIN "ProductCategories" AS "PC" ON 
	"P"."ProductCategoryId" = "P"."Id" INNER JOIN "Markets" as "M" ON
	"P"."MarketId" = "M"."Id"
	WHERE 		
	("pName" IS NULL OR  "P"."Name" ILIKE ('%'||"pName"||'%'))
	AND ("pSku" IS NULL OR  "P"."Sku" ILIKE ('%'||"pSku"||'%'))
	AND ("pMarketId" IS NULL or "P"."MarketId" = "pMarketId")
	AND ("pProductCategoryId" IS NULL or "P"."ProductCategoryId" = "pProductCategoryId")
		AND "M"."IsDeleted" = FALSE	AND "PC"."IsDeleted" = FALSE AND "P"."IsDeleted" = FALSE
	ORDER BY "P"."CreatedAt" DESC
  LIMIT "pLimit"
  OFFSET "pOffset";
end;
$function$
;
