CREATE OR REPLACE FUNCTION public.fn_person_getbyusername("pUserName" text)
 RETURNS SETOF "Person"
 LANGUAGE plpgsql
AS $function$
BEGIN	
	RETURN QUERY
	SELECT "P".*
	FROM "Person" AS "P"
	INNER JOIN "AspNetUsers" AS "ANU" ON "P"."ApplicationUserId" = "ANU"."Id" 
	WHERE "P"."IsDeleted" = false AND "ANU"."UserName" = "pUserName"
	LIMIT 1;
END; 
$function$
;