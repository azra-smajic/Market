CREATE OR REPLACE FUNCTION public.fn_products_get_by_id("pId" uuid)
 RETURNS SETOF "Products"
 LANGUAGE plpgsql
AS $function$
begin
	RETURN QUERY
	SELECT "PC".*
	FROM "Products" AS "P" INNER JOIN "ProductCategories" as "PC"
	ON "P"."ProductCategoryId" = "PC"."Id"
	WHERE "P"."Id" = "pId" AND "P"."IsDeleted" = FALSE AND "PC"."IsDeleted" = FALSE;
END; 
$function$
;