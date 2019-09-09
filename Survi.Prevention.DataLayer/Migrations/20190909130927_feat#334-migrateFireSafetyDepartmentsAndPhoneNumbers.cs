using Microsoft.EntityFrameworkCore.Migrations;

namespace Survi.Prevention.DataLayer.Migrations
{
    public partial class feat334migrateFireSafetyDepartmentsAndPhoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("update \"user\" as usr " +
	                             "set phone_number = attribute_value " +
	                             "from webuser_attributes " +
	                             "where attribute_name = 'telephone' " +
	                             "and usr.id = id_webuser");

	        migrationBuilder.Sql("insert into user_fire_safety_department (id, fire_safety_department_id, user_id) " +
	                             "select id, id_fire_safety_department as fire_safety_department_id," +
	                             " id_webuser as user_id from webuser_fire_safety_department;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
