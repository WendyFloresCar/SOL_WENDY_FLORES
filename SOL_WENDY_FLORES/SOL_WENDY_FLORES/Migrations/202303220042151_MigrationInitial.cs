namespace SOL_WENDY_FLORES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.USUARIOS",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NUMERODNI = c.String(),
                        NOMBRES = c.String(),
                        APELLIDOS = c.String(),
                        EMAIL = c.String(),
                        TELEFONO = c.String(),
                        ESTADO = c.String(),
                        TIPOUSUARIO = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("SYSTEM.USUARIOS");
        }
    }
}
