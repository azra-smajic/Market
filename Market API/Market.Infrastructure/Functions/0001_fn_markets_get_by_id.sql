CREATE OR REPLACE FUNCTION public.fn_markets_get_by_id("pId" integer)
 RETURNS SETOF "Markets"
 LANGUAGE plpgsql
AS $function$
begin
	RETURN QUERY
	SELECT "M".*
	FROM "Markets" AS "M"
	WHERE "M"."Id" = "pId" AND "M"."IsDeleted" = FALSE;
END; 
$function$
;