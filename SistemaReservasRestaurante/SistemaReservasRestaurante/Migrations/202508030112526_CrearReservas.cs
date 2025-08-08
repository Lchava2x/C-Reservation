namespace SistemaReservasRestaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearReservas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false),
                        MesaId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mesas", t => t.MesaId, cascadeDelete: true)
                .Index(t => t.MesaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "MesaId", "dbo.Mesas");
            DropIndex("dbo.Reservas", new[] { "MesaId" });
            DropTable("dbo.Reservas");
        }
    }
}
