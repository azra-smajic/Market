CREATE OR REPLACE FUNCTION public.fn_productcategories_get_by_parameters("pName" text,"pMarketId" uuid,"pLimit" integer, "pOffset" integer)
 RETURNS TABLE("Id" uuid, "Name" text, "MarketName" text, "TotalRecordsCount" integer)
 LANGUAGE plpgsql
AS $function$
BEGIN	
	RETURN QUERY 
	SELECT "PC"."Id", 
		   "PC"."Name",
		   "M"."Name",
		   (COUNT(*) OVER())::integer AS "TotalRecordsCount"
	FROM "ProductCategories" AS "PC" INNER JOIN "Markets" AS "M" ON 
	"PC"."MarketId" = "M"."Id"
	WHERE 		
	("pName" IS NULL OR  "PC"."Name" ILIKE ('%'||"pName"||'%'))
	AND ("pMarketId" IS NULL or "PC"."MarketId" = "pMarketId")
		AND "M"."IsDeleted" = FALSE	AND "PC"."IsDeleted" = FALSE
	ORDER BY "PC"."Name" ASC
  LIMIT "pLimit"
  OFFSET "pOffset";
end;
$function$;