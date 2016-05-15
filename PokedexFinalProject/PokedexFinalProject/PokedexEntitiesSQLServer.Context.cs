﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokedexFinalProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PokedexEntities : DbContext
    {
        public PokedexEntities()
            : base("name=PokedexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LogData> LogDatas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Evolucion> Evolucions { get; set; }
        public virtual DbSet<Habilidad> Habilidads { get; set; }
        public virtual DbSet<Juego> Juegos { get; set; }
        public virtual DbSet<Move> Moves { get; set; }
        public virtual DbSet<Pokemon> Pokemons { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<Tipo> Tipoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<GetAllPokemon> GetAllPokemons { get; set; }
    
        public virtual ObjectResult<ActiveUsers_Month_Result> ActiveUsers_Month()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ActiveUsers_Month_Result>("ActiveUsers_Month");
        }
    
        public virtual ObjectResult<ActiveUsers_Week_Result> ActiveUsers_Week()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ActiveUsers_Week_Result>("ActiveUsers_Week");
        }
    
        public virtual int CreateAbility(string name, string description)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateAbility", nameParameter, descriptionParameter);
        }
    
        public virtual int CreateEvolution(Nullable<int> pokeID, Nullable<int> antID, Nullable<int> sigID, string status, string descripcion)
        {
            var pokeIDParameter = pokeID.HasValue ?
                new ObjectParameter("PokeID", pokeID) :
                new ObjectParameter("PokeID", typeof(int));
    
            var antIDParameter = antID.HasValue ?
                new ObjectParameter("AntID", antID) :
                new ObjectParameter("AntID", typeof(int));
    
            var sigIDParameter = sigID.HasValue ?
                new ObjectParameter("SigID", sigID) :
                new ObjectParameter("SigID", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateEvolution", pokeIDParameter, antIDParameter, sigIDParameter, statusParameter, descripcionParameter);
        }
    
        public virtual int CreateGame(string name, Nullable<System.DateTime> year, string generation, string region)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(System.DateTime));
    
            var generationParameter = generation != null ?
                new ObjectParameter("Generation", generation) :
                new ObjectParameter("Generation", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateGame", nameParameter, yearParameter, generationParameter, regionParameter);
        }
    
        public virtual int CreateGameRelation(Nullable<int> pokeID, Nullable<int> gameID)
        {
            var pokeIDParameter = pokeID.HasValue ?
                new ObjectParameter("PokeID", pokeID) :
                new ObjectParameter("PokeID", typeof(int));
    
            var gameIDParameter = gameID.HasValue ?
                new ObjectParameter("GameID", gameID) :
                new ObjectParameter("GameID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateGameRelation", pokeIDParameter, gameIDParameter);
        }
    
        public virtual int CreateMove(Nullable<int> type, string name, Nullable<int> accuracy, Nullable<int> power, Nullable<int> powerPoints, Nullable<int> generation)
        {
            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var accuracyParameter = accuracy.HasValue ?
                new ObjectParameter("Accuracy", accuracy) :
                new ObjectParameter("Accuracy", typeof(int));
    
            var powerParameter = power.HasValue ?
                new ObjectParameter("Power", power) :
                new ObjectParameter("Power", typeof(int));
    
            var powerPointsParameter = powerPoints.HasValue ?
                new ObjectParameter("PowerPoints", powerPoints) :
                new ObjectParameter("PowerPoints", typeof(int));
    
            var generationParameter = generation.HasValue ?
                new ObjectParameter("Generation", generation) :
                new ObjectParameter("Generation", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateMove", typeParameter, nameParameter, accuracyParameter, powerParameter, powerPointsParameter, generationParameter);
        }
    
        public virtual int CreateMoveRelation(Nullable<int> pokeID, Nullable<int> moveID)
        {
            var pokeIDParameter = pokeID.HasValue ?
                new ObjectParameter("PokeID", pokeID) :
                new ObjectParameter("PokeID", typeof(int));
    
            var moveIDParameter = moveID.HasValue ?
                new ObjectParameter("MoveID", moveID) :
                new ObjectParameter("MoveID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateMoveRelation", pokeIDParameter, moveIDParameter);
        }
    
        public virtual int CreatePokemon(string nombre, Nullable<int> peso, Nullable<double> altura, Nullable<int> generacion, Nullable<int> tipoID, Nullable<int> tipoID2, Nullable<int> habilidadID, Nullable<int> hP, Nullable<int> attack, Nullable<int> defense, Nullable<int> speed, Nullable<int> splAttack, Nullable<int> splDefense)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var pesoParameter = peso.HasValue ?
                new ObjectParameter("Peso", peso) :
                new ObjectParameter("Peso", typeof(int));
    
            var alturaParameter = altura.HasValue ?
                new ObjectParameter("Altura", altura) :
                new ObjectParameter("Altura", typeof(double));
    
            var generacionParameter = generacion.HasValue ?
                new ObjectParameter("Generacion", generacion) :
                new ObjectParameter("Generacion", typeof(int));
    
            var tipoIDParameter = tipoID.HasValue ?
                new ObjectParameter("TipoID", tipoID) :
                new ObjectParameter("TipoID", typeof(int));
    
            var tipoID2Parameter = tipoID2.HasValue ?
                new ObjectParameter("TipoID2", tipoID2) :
                new ObjectParameter("TipoID2", typeof(int));
    
            var habilidadIDParameter = habilidadID.HasValue ?
                new ObjectParameter("HabilidadID", habilidadID) :
                new ObjectParameter("HabilidadID", typeof(int));
    
            var hPParameter = hP.HasValue ?
                new ObjectParameter("HP", hP) :
                new ObjectParameter("HP", typeof(int));
    
            var attackParameter = attack.HasValue ?
                new ObjectParameter("Attack", attack) :
                new ObjectParameter("Attack", typeof(int));
    
            var defenseParameter = defense.HasValue ?
                new ObjectParameter("Defense", defense) :
                new ObjectParameter("Defense", typeof(int));
    
            var speedParameter = speed.HasValue ?
                new ObjectParameter("Speed", speed) :
                new ObjectParameter("Speed", typeof(int));
    
            var splAttackParameter = splAttack.HasValue ?
                new ObjectParameter("SplAttack", splAttack) :
                new ObjectParameter("SplAttack", typeof(int));
    
            var splDefenseParameter = splDefense.HasValue ?
                new ObjectParameter("SplDefense", splDefense) :
                new ObjectParameter("SplDefense", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePokemon", nombreParameter, pesoParameter, alturaParameter, generacionParameter, tipoIDParameter, tipoID2Parameter, habilidadIDParameter, hPParameter, attackParameter, defenseParameter, speedParameter, splAttackParameter, splDefenseParameter);
        }
    
        public virtual int CreateType(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateType", nameParameter);
        }
    
        public virtual int CreateTypeRelation(Nullable<int> iD, string ventaja, string detailVentaja, string debilidad, string detailDebilidad)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var ventajaParameter = ventaja != null ?
                new ObjectParameter("Ventaja", ventaja) :
                new ObjectParameter("Ventaja", typeof(string));
    
            var detailVentajaParameter = detailVentaja != null ?
                new ObjectParameter("DetailVentaja", detailVentaja) :
                new ObjectParameter("DetailVentaja", typeof(string));
    
            var debilidadParameter = debilidad != null ?
                new ObjectParameter("Debilidad", debilidad) :
                new ObjectParameter("Debilidad", typeof(string));
    
            var detailDebilidadParameter = detailDebilidad != null ?
                new ObjectParameter("DetailDebilidad", detailDebilidad) :
                new ObjectParameter("DetailDebilidad", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTypeRelation", iDParameter, ventajaParameter, detailVentajaParameter, debilidadParameter, detailDebilidadParameter);
        }
    
        public virtual int CreateUser(string firstName, string lastName, Nullable<System.DateTime> dOB, string username, string password, string email)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUser", firstNameParameter, lastNameParameter, dOBParameter, usernameParameter, passwordParameter, emailParameter);
        }
    
        public virtual ObjectResult<GetLoginDays_Result> GetLoginDays()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLoginDays_Result>("GetLoginDays");
        }
    
        public virtual ObjectResult<GetLoginHours_Result> GetLoginHours()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLoginHours_Result>("GetLoginHours");
        }
    
        public virtual ObjectResult<GetPokemonByGame_Result> GetPokemonByGame(Nullable<int> gameID)
        {
            var gameIDParameter = gameID.HasValue ?
                new ObjectParameter("GameID", gameID) :
                new ObjectParameter("GameID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPokemonByGame_Result>("GetPokemonByGame", gameIDParameter);
        }
    
        public virtual ObjectResult<GetPokemonById_Result> GetPokemonById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPokemonById_Result>("GetPokemonById", idParameter);
        }
    
        public virtual ObjectResult<GetPokemonByName_Result> GetPokemonByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPokemonByName_Result>("GetPokemonByName", nameParameter);
        }
    
        public virtual ObjectResult<GetPokemonDetail_Result> GetPokemonDetail(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPokemonDetail_Result>("GetPokemonDetail", idParameter);
        }
    
        public virtual ObjectResult<GetPokemonEvolutions_Result> GetPokemonEvolutions(Nullable<int> pokeID)
        {
            var pokeIDParameter = pokeID.HasValue ?
                new ObjectParameter("PokeID", pokeID) :
                new ObjectParameter("PokeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPokemonEvolutions_Result>("GetPokemonEvolutions", pokeIDParameter);
        }
    
        public virtual ObjectResult<GetTypeRelations_Result> GetTypeRelations(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTypeRelations_Result>("GetTypeRelations", idParameter);
        }
    
        public virtual ObjectResult<GetUserContains_Result> GetUserContains(string patron)
        {
            var patronParameter = patron != null ?
                new ObjectParameter("patron", patron) :
                new ObjectParameter("patron", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserContains_Result>("GetUserContains", patronParameter);
        }
    
        public virtual ObjectResult<InactiveUsers_Month_Result> InactiveUsers_Month()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InactiveUsers_Month_Result>("InactiveUsers_Month");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<SPByUser_Result> SPByUser(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("Userid", userid) :
                new ObjectParameter("Userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPByUser_Result>("SPByUser", useridParameter);
        }
    }
}
