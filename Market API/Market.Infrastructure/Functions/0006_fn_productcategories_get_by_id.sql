CREATE OR REPLACE FUNCTION public.fn_productcategories_get_by_id("pId" integer)
 RETURNS SETOF "ProductCategories"
 LANGUAGE plpgsql
AS $function$
begin
	RETURN QUERY
	SELECT "PC".*
	FROM "ProductCategories" AS "PC"
	WHERE "PC"."Id" = "pId" AND "PC"."IsDeleted" = FALSE;
END; 
$function$
;