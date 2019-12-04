 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace testudines.cls.bbdd.itis
{
    public class ClsReg_ITIS_TSN
    {
        string _mMySqlConnectionString = "";
        public ClsReg_ITIS_TSN(string szMySqlConnectionString)
        {
            _mMySqlConnectionString = szMySqlConnectionString;
        }
        private testudines.cls.bbdd.itis.ClsRegTaxonomic_units oTax_Taxon = new ClsRegTaxonomic_units(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegTaxonomic_units Tax_Taxon { get { return oTax_Taxon; } }

        private testudines.cls.bbdd.itis.ClsRegHierarchy oTax_Hierarchy = new ClsRegHierarchy(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegHierarchy Tax_Hierarchy { get { return oTax_Hierarchy; } }

        private testudines.cls.bbdd.itis.ClsRegTaxon_unit_types oTax_unit_types = new testudines.cls.bbdd.itis.ClsRegTaxon_unit_types(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegTaxon_unit_types Tax_unit_types { get { return oTax_unit_types; } }

        private testudines.cls.bbdd.itis.ClsRegTaxon_authors_lkp oTax_authors = new ClsRegTaxon_authors_lkp(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegTaxon_authors_lkp Tax_authors { get { return oTax_authors; } }


        private testudines.cls.bbdd.itis.ClsRegKingdoms oTaxKindon = new ClsRegKingdoms(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegKingdoms TaxKindon { get { return oTaxKindon; } }


        private testudines.cls.bbdd.itis.ClsRegReference_links oTaxReferences = new ClsRegReference_links(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegReference_links TaxReferences { get { return oTaxReferences; } }

        private testudines.cls.bbdd.itis.ClsRegVern_ref_links oTaxVernaculars = new ClsRegVern_ref_links(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegVern_ref_links TaxVernaculars { get { return oTaxVernaculars; } }


        private testudines.cls.bbdd.itis.ClsRegSynonym_links oTaxSynonyms = new ClsRegSynonym_links(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegSynonym_links TaxSynonyms { get { return oTaxSynonyms; } }

        private testudines.cls.bbdd.itis.ClsRegTu_comments_links oTaxComments = new ClsRegTu_comments_links(cls.ClsGlobal.Connection_MARIADB_ITIS);
        public testudines.cls.bbdd.itis.ClsRegTu_comments_links TaxComments { get { return oTaxComments; } }

        private void FncClear()
        {
            oTax_Taxon.FncClear();
            oTax_unit_types.FncClear();
            oTaxKindon.FncClear();
            oTax_authors.FncClear();
            oTax_Hierarchy.FncClear(); // pte list
            
            oTaxReferences.FncClear();// pte list
            oTaxVernaculars.FncClear();// pte list
            oTaxSynonyms.FncClear();// pte list
            oTaxComments.FncClear();// pte list 
        }
        public bool FncFind(int idTSN)

        {
            bool b = true;
            DataTable oTb = new DataTable();
            FncFillDatatableItis(idTSN, ref oTb);
            if (oTb.Rows.Count == 0){ return false; }
            FncClear();
           
            if (b) { b = oTax_unit_types.FncSqlFind(oTax_Taxon.kingdom_id, oTax_Taxon.rank_id); };
            if (b){ b = oTax_Hierarchy.FncSqlFindTsn(oTax_Taxon.tsn); }
            if (b){ b = oTax_authors.FncSqlFind(oTax_Taxon.taxon_author_id); }
            if (b) { b = oTaxKindon.FncSqlFind(oTax_Taxon.kingdom_id); }
            if (b) { b = oTaxReferences.FncSqlFind(oTax_Taxon.tsn); }
            if (b) { b = oTaxVernaculars.FncSqlFind(oTax_Taxon.tsn); }
            if (b) { b = oTaxSynonyms.FncSqlFind(oTax_Taxon.tsn); }
            if (b) { b = oTaxComments.FncSqlFind(oTax_Taxon.tsn); }

            
            return b;
        }
        private void FncFillDatatableItis(int idTsn, ref DataTable oTb)
        {
            /*
             WITH RECURSIVE ancestors AS  ( SELECT * FROM hierarchy    WHERE TSN=551866 or parent_tsn=551866 UNION  SELECT f.*  FROM hierarchy AS f, ancestors AS a   WHERE f.TSN = a.Parent_TSN  )
 SELECT  ancestors.Parent_TSN, ancestors.tsn,ancestors.hierarchy_string,
 taxonomic_units.complete_name, taxonomic_units.rank_id,taxon_unit_types.rank_name, taxonomic_units.complete_name, 
 CASE WHEN taxon_authors_lkp.taxon_author IS NOT NULL THEN concat (' (',taxon_authors_lkp.taxon_author,')')ELSE ""END AS Author, 
 unit_name1,unit_name2, unit_name3,  taxonomic_units.`usage`,  taxonomic_units.`unaccept_reason`,  taxonomic_units.`credibility_rtng`,  taxonomic_units.`currency_rating`,
  taxonomic_units.taxon_author_id,taxonomic_units.kingdom_id, taxonomic_units.update_date 
 FROM ancestors LEFT JOIN taxonomic_units ON taxonomic_units.tsn = ancestors.tsn
 LEFT JOIN taxon_unit_types ON taxonomic_units.kingdom_id = taxon_unit_types.kingdom_id and taxonomic_units.rank_id = taxon_unit_types.rank_id 
 LEFT JOIN taxon_authors_lkp ON taxonomic_units.taxon_author_id = taxon_authors_lkp.taxon_author_id 
 LEFT JOIN geographic_div ON taxonomic_units.tsn = geographic_div.tsn order by taxonomic_units.rank_id, taxonomic_units.unit_name3 
              */
            String szIdTsn = idTsn.ToString();
            String szSql = "";
            szSql += "WITH RECURSIVE ancestors AS  ( SELECT * FROM hierarchy    WHERE TSN="+ szIdTsn+ "or parent_tsn="+ szIdTsn + " UNION  SELECT f.*  FROM hierarchy AS f, ancestors AS a   WHERE f.TSN = a.Parent_TSN) ";
            szSql += "SELECT  ancestors.Parent_TSN, ancestors.tsn,ancestors.hierarchy_string, ";
            szSql += "taxonomic_units.complete_name, taxonomic_units.rank_id,taxon_unit_types.rank_name, taxonomic_units.complete_name, ";
            szSql += "CASE WHEN taxon_authors_lkp.taxon_author IS NOT NULL THEN concat (' (',taxon_authors_lkp.taxon_author,')')ELSE END AS Author, ";
            szSql += "unit_name1,unit_name2, unit_name3,  taxonomic_units.`usage`,  taxonomic_units.`unaccept_reason`,  taxonomic_units.`credibility_rtng`,  taxonomic_units.`currency_rating`, ";
            szSql += "taxonomic_units.taxon_author_id,taxonomic_units.kingdom_id, taxonomic_units.update_date ";
            szSql += "FROM ancestors LEFT JOIN taxonomic_units ON taxonomic_units.tsn = ancestors.tsn ";
            szSql += "LEFT JOIN taxon_unit_types ON taxonomic_units.kingdom_id = taxon_unit_types.kingdom_id and taxonomic_units.rank_id = taxon_unit_types.rank_id  ";
            szSql += "LEFT JOIN taxon_authors_lkp ON taxonomic_units.taxon_author_id = taxon_authors_lkp.taxon_author_id ";
            szSql += "LEFT JOIN geographic_div ON taxonomic_units.tsn = geographic_div.tsn order by taxonomic_units.rank_id, taxonomic_units.unit_name3 ";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTb);
        }
        // busca en itis y taxons las no coincidencias
        public string FncSqlNoMatch()
        {
            string szCmd= "select `t`.`DocId` AS `DocId`,`i`.`tsn` AS `tsn`,`t`.`ATaxGrpL2270Genus` AS `ATaxGrpL2270Genus`,`i`.`unit_name1` AS `unit_name1`,`t`.`ATaxGrpL2280Specie` AS `ATaxGrpL2280Specie`,`i`.`unit_name2` AS `unit_name2` from (`testudines20`.`tdoclng_testudines_taxa_all` `t` left join `itis-2018`.`taxonomic_units` `i` on(`t`.`ATaxGrpL2270Genus` = `i`.`unit_name1` and `t`.`ATaxGrpL2280Specie` = `i`.`unit_name2`)) where `t`.`DocId` is null or `i`.`tsn` is null union select `t`.`DocId` AS `DocId`,`i`.`tsn` AS `tsn`,`t`.`ATaxGrpL2270Genus` AS `ATaxGrpL2270Genus`,`i`.`unit_name1` AS `unit_name1`,`t`.`ATaxGrpL2280Specie` AS `ATaxGrpL2280Specie`,`i`.`unit_name2` AS `unit_name2` from (`itis-2018`.`taxonomic_units` `i` left join `testudines20`.`tdoclng_testudines_taxa_all` `t` on(`t`.`ATaxGrpL2270Genus` = `i`.`unit_name1` and `t`.`ATaxGrpL2280Specie` = `i`.`unit_name2`)) where `t`.`DocId` is null or `i`.`tsn` is null";
        return szCmd;
                }

        public string FncBldHtml() {
            String szHtml = "";
            return szHtml;
        }
        public String FncCheckTaxonToItis()
        {
            String szReturn = "";
            DataTable oTb_taxon = new DataTable();
            return szReturn;
        }
    }
}