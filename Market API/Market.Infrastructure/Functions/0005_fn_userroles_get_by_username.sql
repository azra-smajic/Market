CREATE OR REPLACE FUNCTION public.fn_userroles_getbyusername("pUsername" text)
 RETURNS SETOF "AspNetUserRoles"
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
    SELECT "ANUR".*
    FROM "AspNetUserRoles" AS "ANUR"
    INNER JOIN "AspNetUsers" as "ANU"
    ON "ANU"."Id" = "ANUR"."UserId"
    WHERE "ANU"."UserName" = "pUsername" AND "ANUR"."IsDeleted" = FALSE;
END;
$function$;