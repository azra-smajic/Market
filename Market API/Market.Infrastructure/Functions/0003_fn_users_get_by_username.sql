CREATE OR REPLACE FUNCTION public.fn_users_getbyusername("pUserName" text)
 RETURNS SETOF "AspNetUsers"
 LANGUAGE plpgsql
AS $function$
BEGIN   
	RETURN QUERY 
	SELECT *
	FROM "AspNetUsers" AS "ANR" 	
	WHERE "ANR"."UserName" = "pUserName" AND "ANR"."IsDeleted" = FALSE;	
END;
$function$
;
 