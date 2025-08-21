CREATE OR REPLACE FUNCTION public.fn_productimages_get_by_productid("pId" uuid)
 RETURNS SETOF "ProductImages"
 LANGUAGE plpgsql
AS $function$
begin
	RETURN QUERY
	SELECT "PI".*
	FROM "ProductImages" AS "PI" INNER JOIN Product as "P"
	ON "PI"."ProductId" = "P"."Id"
	WHERE "PI"."ProductId" = "pId" AND "P"."IsDeleted" = FALSE AND "PI"."IsDeleted" = FALSE;
END; 
$function$
;