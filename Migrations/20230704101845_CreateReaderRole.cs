using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMigrations.Migrations
{
    public partial class CreateReaderRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DO
                $do$
                BEGIN
                   IF NOT EXISTS (
                      SELECT FROM pg_catalog.pg_roles  WHERE rolname = 'reader') THEN
                      CREATE ROLE reader;
                   END IF;
                END
                $do$
            ");

            migrationBuilder.Sql(@"GRANT USAGE ON SCHEMA dbo TO reader");
            migrationBuilder.Sql(@"GRANT SELECT ON ALL TABLES IN SCHEMA dbo TO reader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"REVOKE ALL ON SCHEMA dbo FROM reader");
            migrationBuilder.Sql(@"REVOKE ALL ON ALL TABLES IN SCHEMA dbo FROM reader");
            migrationBuilder.Sql(@"DROP ROLE IF EXISTS reader");
        }
    }
}
