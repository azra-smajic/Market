CREATE OR REPLACE FUNCTION public.fn_markets_get_by_parameters("pName" text,"pLocation" text,"pLimit" integer, "pOffset" integer)
 RETURNS TABLE("Id" uuid, "Name" text, "Location" text, "TotalRecordsCount" integer)
 LANGUAGE plpgsql
AS $function$
BEGIN	
	RETURN QUERY 
	SELECT "M"."Id", 
		   "M"."Name",
		   "M"."Location",
		   (COUNT(*) OVER())::integer AS "TotalRecordsCount"
	FROM "Markets" AS "M"
	WHERE 		
	("pName" IS NULL OR  "M"."Name" ILIKE ('%'||"pName"||'%'))
	AND ("pLocation" IS NULL or "M"."Location" ILIKE ('%'||"pLocation"||'%'))
		AND "M"."IsDeleted" = FALSE	
	ORDER BY "M"."Name" ASC
  LIMIT "pLimit"
  OFFSET "pOffset";
end;
$function$;