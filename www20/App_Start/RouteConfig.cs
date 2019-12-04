


using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace testudines
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("", "test/", "~/a_test/default.aspx");

            //es/a_dlg/dlg_iucn_redlist/4
            routes.MapPageRoute("", "dlg_iucn_redlist/{docid}", "~/a_dlg/dlg_iucn_redlist.aspx");
            routes.MapPageRoute("", "{doclngid}/dlg_iucn_redlist/{docid}", "~/a_dlg/dlg_iucn_redlist.aspx");
            routes.MapPageRoute("", "{doclngid}/dlg_ecozone_help/{EcozoneListCode}", "~/a_dlg/dlg_ecozone_help.aspx");

            /* tortoises */

            //es/tortoises/tortoise/tortoise
            ///es/tortoises/tortoise/1/description
            ///
            
            //  es/tortoises/tortoise-images/Acanthochelys-macrocephala/2
            ///es/tortoises/images
            routes.MapPageRoute("", "{doclngid}/tortoises/images/{docid}/{page}", "~/tortoises/images.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/images/{docid}", "~/tortoises/images.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/images", "~/tortoises/images.aspx");

            routes.MapPageRoute("", "foods/", "~/tortoises/foods/foods.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/foods/foods-list", "~/tortoises/foods/foods-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/foods/food/{docid}", "~/tortoises/foods/food.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/foods/foods-mng-list", "~/tortoises/foods/foods-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/foods/food-mng-edit/{docid}", "~/tortoises/foods/food-mng-edit.aspx");

            routes.MapPageRoute("", "{doclngid}/tortoises/tortoises-taxonomy-list/", "~/tortoises/tortoises-taxonomy-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/groups/groups-list/", "~/tortoises/tortoises-taxonomy-list.aspx");
        

            routes.MapPageRoute("", "{doclngid}/tortoises/tortoises-list/", "~/tortoises/tortoises-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/{docid}/{capitule}", "~/tortoises/tortoise.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/{docid}", "~/tortoises/tortoise.aspx");
            

            routes.MapPageRoute("", "{doclngid}/tortoises/{docid}/{capitule}", "~/tortoises/tortoise.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/{docid}", "~/tortoises/tortoise.aspx");
            ///tortoises/tortoise/tortoises-list);





            ///tortoises/foods/foods-list /tortoises/foods/foods-list

        



            /* ARTICLES */
            routes.MapPageRoute("", "{doclngid}/articles/articles-list", "~/articles/articles-list.aspx");
            routes.MapPageRoute("", "{doclngid}/articles/articles-list/{filter}", "~/articles/articles-list.aspx");
            routes.MapPageRoute("", "{doclngid}/articles/article/{docid}", "~/articles/article.aspx");
            routes.MapPageRoute("", "{doclngid}/articles/articles-mng-list", "~/articles/articles-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/articles/article-mng-edit/{docid}", "~/articles/article-mng-edit.aspx");

            /* NOTICES */
            routes.MapPageRoute("", "notices", "~/notices/notices-list.aspx");
            routes.MapPageRoute("", "{doclngid}/notices/notices-list", "~/notices/notices-list.aspx");
            routes.MapPageRoute("", "{doclngid}/notices/notice/{docid}", "~/notices/notice.aspx");
            routes.MapPageRoute("", "{doclngid}/notices/notices-mng-list", "~/notices/notices-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/notices/notice-mng-edit/{docid}", "~/notices/notice-mng-edit.aspx");

            /* others */
            routes.MapPageRoute("", "others", "~/others/others-list.aspx");
            routes.MapPageRoute("", "{doclngid}/others/others-list", "~/others/others-list.aspx");
            routes.MapPageRoute("", "{doclngid}/others/other/{docid}", "~/others/other.aspx");
            routes.MapPageRoute("", "{doclngid}/others/others-mng-list", "~/others/others-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/others/other-mng-edit/{docid}", "~/others/other-mng-edit.aspx");
            /*/es/others/acknowledgement-mng-edit/41448*/

            /*images*/
            routes.MapPageRoute("", "{doclngid}/images", "~/images/images.aspx");


            routes.MapPageRoute("", "appendixes/", "~/tortoises/appendixes/appendixes-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/appendixes/appendixes-list", "~/tortoises/appendixes/appendixes-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/appendixes/appendix/{docid}", "~/tortoises/appendixes/appendix.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/appendixes/appendixes-mng-list", "~/tortoises/appendixes/appendixes-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/appendixes/appendix-mng-edit/{docid}", "~/tortoises/appendixes/appendix-mng-edit.aspx");


            routes.MapPageRoute("", "{doclngid}/tortoises/groups/groups-list", "~/tortoises/groups/groups-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/groups/group/{docid}", "~/tortoises/groups/group.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/groups/groups-mng-list", "~/tortoises/groups/groups-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/groups/group-mng-edit/{docid}", "~/tortoises/groups/group-mng-edit.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/keys/keys-list", "~/tortoises/keys/keys-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/keys/key/{docid}", "~/tortoises/keys/key.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/keys/keys-mng-list", "~/tortoises/keys/keys-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/keys/key-mng-edit/{docid}", "~/tortoises/keys/key-mng-edit.aspx");
            routes.MapPageRoute("", "{doclngid}/tortoises/foods/food-mng-edit/{docid}", "~/tortoises/foods/food-mng-edit.aspx");

            routes.MapPageRoute("", "{doclngid}/acknowledgements/acknowledgement/{docid}", "~/acknowledgements/acknowledgement.aspx");
            routes.MapPageRoute("", "{doclngid}/acknowledgements/acknowledgements-list/", "~/acknowledgements/acknowledgements-list.aspx");
            routes.MapPageRoute("", "{doclngid}/acknowledgements/acknowledgement-mng-edit/{docid}", "~/acknowledgements/acknowledgement-mng-edit.aspx");
            routes.MapPageRoute("", "{doclngid}/acknowledgements/acknowledgements-mng-list", "~/acknowledgements/acknowledgements-mng-list.aspx");


            /*
            routes.MapPageRoute("", "references/", "~/others/references/references.aspx");
            routes.MapPageRoute("", "{doclngid}/others/references/references", "~/others/references/references.aspx");
            routes.MapPageRoute("", "{doclngid}/others/references/reference/{docid}", "~/others/references/reference.aspx");
            routes.MapPageRoute("", "{doclngid}/others/references/reference_mng_list", "~/others/references/reference_mng_list.aspx");
            routes.MapPageRoute("", "{doclngid}/others/references/reference_mng_edite/{docid}", "~/others/references/references_mng_edit.aspx");
            */

            /*en/others/ecozones/ecozone-mng-edit */
            routes.MapPageRoute("", "ecozones/", "~/ecozones/ecozones-list.aspx");
            routes.MapPageRoute("", "{doclngid}/ecozones/ecozones-list", "~/ecozones/ecozones-list.aspx");
            routes.MapPageRoute("", "{doclngid}/ecozones/ecozone/{docid}", "~/ecozones/ecozone.aspx");
            routes.MapPageRoute("", "{doclngid}/ecozones/ecozones-mng-list", "~/ecozones/ecozones-mng-list.aspx");
            routes.MapPageRoute("", "{doclngid}/ecozones/ecozone-mng-edit/{docid}", "~/ecozones/ecozone-mng-edit.aspx");
            /* ------ */
        

            routes.MapPageRoute("", "{doclngid}/bibliography/bibliography-list", "~/bibliography/bibliography-list.aspx");
            routes.MapPageRoute("", "{doclngid}/bibliography/bibliography/{docid}", "~/bibliography/bibliography.aspx");
            routes.MapPageRoute("", "{doclngid}/bibliography/bibliography-mng-list", "~/bibliography/bibliography-mng-list");
            routes.MapPageRoute("", "{doclngid}/bibliography/bibliography-mng-edit/{docid}", "~/bibliography/bibliography-mng-edit");


            ///others/iucn/iucn-list\
            routes.MapPageRoute("", "{doclngid}/iucn/iucn-list", "~/iucn/iucn-list.aspx");
            routes.MapPageRoute("", "{doclngid}/iucn/iucn/{docid}", "~/iucn/iucn.aspx");
            routes.MapPageRoute("", "{doclngid}/iucn/iucn-mng-list", "~/iucn/iucn-mng-list");
            routes.MapPageRoute("", "{doclngid}/iucn/iucn-mng-edit/{docid}", "~/iucn/iucn/iucn-mng-edit");

            routes.MapPageRoute("", "{doclngid}/cache/cache-mng", "~/cache/cache-mng.aspx");
            /*
             *  "/cache/cache-mng/"
             * 
           routes.Add("articles", new Route("{doclngid}/articles", new clsRouteHandler("~/articles/default.aspx")));
            routes.Add("articleslist", new Route("{doclngid}/articles/{type}", new clsRouteHandler("~/articles/articles.aspx")));
            routes.Add("articles_mng", new Route("{doclngid}/articles_mng/{type}", new clsRouteHandler("~/articles/articles_mng.aspx")));


            routes.Add("notice", new Route("{doclngid}/notices/notice/{docid}", new clsRouteHandler("~/notices/notice.aspx")));
            routes.Add("notices", new Route("{doclngid}/notices", new clsRouteHandler("~/notices/notices.aspx")));
            routes.Add("noticeslist", new Route("{doclngid}/notices/{type}", new clsRouteHandler("~/notices/notices.aspx")));
            routes.Add("notices_mng", new Route("{doclngid}/notices/notices_mng/", new clsRouteHandler("~/notices/notices_mng.aspx")));

         
            routes.Add("other_other", new Route("{doclngid}/others/other/{docid}", new clsRouteHandler("~/others/others/other.aspx")));
            
            routes.Add("other_others", new Route("{doclngid}/others/others", new clsRouteHandler("~/others/others/others.aspx")));
            routes.Add("other_otherslist", new Route("{doclngid}/others/others/{type}", new clsRouteHandler("~/others/others/others.aspx")));
            routes.Add("other_other_mng", new Route("{doclngid}/others/others/others_mng/", new clsRouteHandler("~/others/others/other_mng.aspx")));

            routes.Add("media", new Route("{doclngid}/medias/media/{docid}", new clsRouteHandler("~/medias/media.aspx")));
            routes.Add("medias", new Route("{doclngid}/medias/{gal}", new clsRouteHandler("~/medias/medias_gal.aspx")));
            routes.Add("medias_alt", new Route("{doclngid}/medias", new clsRouteHandler("~/medias/medias_gal.aspx")));
            routes.Add("medias_mng", new Route("{doclngid}/medias_mng/", new clsRouteHandler("~/medias/medias_mng.aspx")));

            routes.Add("appendix", new Route("{doclngid}/others/appendixes/appendix/{docid}", new clsRouteHandler("~/others/appendixes/appendix.aspx")));
            routes.Add("other_appendixes", new Route("{doclngid}/others/appendixes", new clsRouteHandler("~/others/appendixes/appendixes.aspx")));
            routes.Add("other_appendixeslist", new Route("{doclngid}others/appendixes/{type}", new clsRouteHandler("~/others/appendixes/appendixes.aspx")));
            routes.Add("other_appendixes_mng", new Route("{doclngid}others/appendixes_mng/", new clsRouteHandler("~/others/appendixes/appendixes_mng.aspx")));

            routes.Add("other_ecozones2", new Route("{doclngid}/others/ecogeography/ecozone/{docid}", new clsRouteHandler("~/others/ecogeography/ecozones.aspx")));
            routes.Add("other_ecozone", new Route("{doclngid}/others/ecogeography/ecozone/{docid}", new clsRouteHandler("~/others/ecogeography/ecozone.aspx")));
            routes.Add("other_ecozones", new Route("{doclngid}/others/ecogeography", new clsRouteHandler("~/others/ecogeography/ecozones.aspx")));
            routes.Add("other_ecozones_mng", new Route("{doclngid}/others/ecogeography/ecozone_mng/", new clsRouteHandler("~/others/ecogeography/ecozones_mng.aspx")));


            routes.Add("other_food", new Route("{doclngid}/others/foods/food/{docid}", new clsRouteHandler("~/others/foods/food.aspx")));
            routes.Add("other_foods", new Route("{doclngid}/others/foods", new clsRouteHandler("~/others/foods/foods.aspx")));
            routes.Add("other_foodslist", new Route("{doclngid}/others/foods/{type}", new clsRouteHandler("~/others/foods/foods.aspx")));
            routes.Add("other_foods_mng", new Route("{doclngid}/others/foods_mng/", new clsRouteHandler("~/others/foods/foods_mng.aspx")));


            routes.Add("reference", new Route("{doclngid}/others/references/reference/{docid}", new clsRouteHandler("~/others/references/reference.aspx")));
            routes.Add("other_references", new Route("{doclngid}/others/references", new clsRouteHandler("~/others/references/references.aspx")));
            routes.Add("other_referencelist", new Route("{doclngid}/others/references/references/{type}", new clsRouteHandler("~/others/references/references.aspx")));
            
            routes.Add("other_referenceAgreetment", new Route("{doclngid}/Acknowledgements", new clsRouteHandler("~/others/references/Acknowledgements.aspx")));


            routes.Add("other_todo", new Route("{doclngid}/others/todo/todo/{docid}", new clsRouteHandler("~/others/todo/todo.aspx")));
            routes.Add("other_todos", new Route("{doclngid}others/todos", new clsRouteHandler("~/others/todo/todos.aspx")));
            routes.Add("other_todolist", new Route("{doclngid}others/todo/todos/{type}", new clsRouteHandler("~/others/todo/todos.aspx")));

          
            routes.Add("other_tools", new Route("{doclngid}/others/tools", new clsRouteHandler("~/others/tools/default.aspx")));
            routes.Add("other_toolsPancur", new Route("{doclngid}/others/tools/panacurcalculator/{docid}", new clsRouteHandler("~/others/tools/PanacurCalculator.aspx")));
            routes.Add("other_siunitcalculator", new Route("{doclngid}/others/tools/siunitcalculator", new clsRouteHandler("~/others/tools/siunitcalculator.aspx")));



            routes.Add("contact", new Route("{doclngid}/contact/", new clsRouteHandler("~/a_dlg/dlg_mail.aspx")));
            //es/tools/panacur_calculator/8589D:\_testudines\dev15\www\a_js\fancybox\
            routes.Add("taxon_mgn", new Route("{doclngid}/taxons/taxon_mng/", new clsRouteHandler("~/taxons/taxon_mng.aspx")));
            routes.Add("taxon_mgn_id", new Route("{doclngid}/taxons/taxon_mng/{docid}", new clsRouteHandler("~/taxons/taxon_mng.aspx")));
            routes.Add("taxon_taxon", new Route("{doclngid}/tortoises/{docid}", new clsRouteHandler("~/taxons/taxon.aspx")));
            routes.Add("taxon_tortoise_sec", new Route("{doclngid}/tortoises/{docid}/{section}", new clsRouteHandler("~/taxons/taxon.aspx")));
            routes.Add("taxon_taxons", new Route("{doclngid}/taxons/taxons/", new clsRouteHandler("~/taxons/taxons.aspx")));
            
            //  /es/taxons/taxon_groups/
            routes.Add("taxon_taxongroups", new Route("{doclngid}/taxons/taxon_groups/", new clsRouteHandler("~/taxons/taxon_groups.aspx")));
            routes.Add("taxon_taxongroup", new Route("{doclngid}/taxons/taxon_group/{docid}", new clsRouteHandler("~/taxons/taxon_group.aspx")));
            routes.Add("taxon_taxongroup_mgn", new Route("{doclngid}/taxons/taxon_groups_mng/", new clsRouteHandler("~/taxons/taxon_groups_mng.aspx")));

            routes.Add("taxon_taxons_keys_tree", new Route("{doclngid}/taxons/taxon_keys_tree/", new clsRouteHandler("~/taxons/taxon_keys_tree.aspx")));
            routes.Add("taxon_taxons_keys_mgn", new Route("{doclngid}/taxons/taxon_keys_mng/", new clsRouteHandler("~/taxons/taxon_keys_mng.aspx")));
            routes.Add("taxon_taxons_keys_mgnDocid", new Route("{doclngid}/taxons/taxon_keys_mng/{docid}", new clsRouteHandler("~/taxons/taxon_keys_mng.aspx")));
            routes.Add("taxon_taxons_tortoise_keys_edit", new Route("{doclngid}/taxons/taxon_keys_edit/{docid}", new clsRouteHandler("~/taxons/taxon_keys_mng.aspx")));

                      
            routes.Add("taxon_taxons_key", new Route("{doclngid}/taxons/taxon_key/{docid}", new clsRouteHandler("~/taxons/taxon_key.aspx")));

            routes.Add("user", new Route("{doclngid}/user/{category}/{idnname}/{acction}", new clsRouteHandler("~/user/user.aspx")));

            routes.Add("biblio", new Route("{doclngid}/others/bibliography/{category}/{idname}/{acction}", new clsRouteHandler("~/biblio/blibliograpy.aspx")));
            routes.Add("about", new Route("{doclngid}/about/", new clsRouteHandler("~/about.aspx")));

            routes.Add("useractivate", new Route("{doclngid}/useractivate/{guid}", new clsRouteHandler("~/users/loginProfile.aspx")));
          
             */
        }
    }
}

