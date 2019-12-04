//-----------------------------------------------
function FncShowLoading(bDisplay) {
    if (bDisplay === true) {
        document.getElementById("loading").style.display = 'block';
    } else {
        document.getElementById("loading").style.display = 'none';
    }
}
//-----------------------------------------------
// rellena un div con la respuest de una peticion ajax
// pDivTarget=id del div
// pURLHtml= url a solicitar
function FncLoadAjax(pDivTarget, pURLHtml) {
    //alert(pDivTarget + " , " + pURLHtml)
    FncShowLoading(true);
    var xhttp;
    var reply = "";
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState === 4 && xhttp.status === 200) {
            document.getElementById(pDivTarget).innerHTML = xhttp.responseText;
            $('[data-toggle="tooltip"]').tooltip();
        }
        FncShowLoading(false);
        
        return false;
    };
    xhttp.open("GET", pURLHtml, true);
    xhttp.send();
}


//-----------------------------------------
//-----------------------------------------
//------------------------------------------
//<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
  //  </script>
//-----------------------------------------
//------------------------------------------

//    <script>

        $(document).ready(function () {
            console.log("ready!");


        $(function () {
            $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
        $('.tree li.parent_li > span').on('click', function (e) {
                    var children = $(this).parent('li.parent_li').find(' > ul > li');
                    if (children.is(":visible")) {
            children.hide('fast');
        $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
                    } else {
            children.show('fast');
        $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
                    }
                    e.stopPropagation();
                });
            });
        });
//    </script>
//-----------------------------------------
//------------------------------------------


//    <script>
        $(document).ready(function () {

            /* set height*/
            function setHeight() {
                windowHeight = $(window).innerHeight() - 24;
                $('#wrapper').css('min-height', windowHeight);
            };
        setHeight();

            $(window).resize(function () {
            setHeight();
        });


        });

//    </script>
//-----------------------------------------
//------------------------------------------

//    <script type="text/javascript">
        $(document).ready(function () {



            //tootip

            $('[data-toggle="tooltip"]').tooltip();
        //tootip end



        $(function () {
            $("#btnShowLogin").click(function () {
                $('#DlgLoginModal').modal('show');
            });
        $("#btnShowSearch").click(function () {
            $('#DlgSearchModal').modal('show');
        });
                    /* Send mail              */

                    $('#btnShowMail').on('click', function () {
                        var dataURL = "/a_dlg/dlgmsgmail.aspx";
                        $('.modal-body2').load(dataURL, function () {
            $('#DlgModal').modal({ show: true });
        });
                    });

                });
            });
 //   </script>

//-----------------------------------------
//------------------------------------------


//    <script>
        (function () {
               var cx = '014543056619451341684:0zksptqoi6e';
               var gcse = document.createElement('script');
               gcse.type = 'text/javascript';
               gcse.async = true;
               gcse.src = 'https://cse.google.com/cse.js?cx=' + cx;
               var s = document.getElementsByTagName('script')[0];
               s.parentNode.insertBefore(gcse, s);
           })();
 //   </script>



        //-------------------------------------------------------------------
        // nuevas funciones
        // funciones para llamar al cuadro de dialog de seleccion de paises
        // desde el control /a_dlg/dlgCountries.aspx
        //-----------------------------------------------------------
        function OpenDlgChildCountries() {
            alert("uno");

            var MyArgs = new Array();
            var width = 600;
            var height = 300;

            //cphContent_tbContainer_scnPanHabitat_scnLHabGeoCountryNotes"
            var WinSettings = "center:yes;resizable:no;dialogHeight:600px; dialogWidth:800px; toolbar=no;menubar=no,"; //+", top="+top +", left="+left;
            alert("dos");
            var docid = document.getElementById('scnDocId').innerHTML;
            var url = "/a_dlg/dlg_Countries.aspx?docid=" + docid + "&returnName=scnXX_AGeoCountriesNamesTxt&returnkeys=scnXX_AGeoKeyCountries";
            alert(url);
            popup = window.open(url, "Popup", WinSettings);

            // var MyArgs = window.open("ChildWebForm.aspx", null, "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no");
            if (popup === null) {
                window.alert("Nothing2 returned from child. No changes made to input boxes");
            }
            else {
                document.getElementById('scnXX_AGeoCountriesNamesTxt').value = MyArgs[0].toString();
                document.getElementById('scnXX_AGeoKeyCountries').value = MyArgs[1].toString();
                alert(end);

            }
        }
        //-----------------------------------------------------------
        //  - nuevas funciones
        //  funciones para llamar al cuadro de dialog de imagenes
        // desde el control ctl_imgfld.ascx
        //
        //TheNewWin =window.open("untitled.html",'TheNewpop',
        //'fullscreen=yes,toolbar=no,location=no,directories=no,
        //status=no,menubar=no,scrollbars=no,resizable=no');

        //-----------------------------------------------------------
        // -------------------------------------------------------
        //-----------------------------------------------------------

        var popup;
        function jsOpenDlgGetImg(scnidimg, scnidimgurl) {
            var url = "/ckeditor/ImageBrowserFld.aspx?scnidimg=" + scnidimg + "&filter=0"
            //var url = "Popup.htm?idName=" + scnidimg
            // popup = window.open("Popup.htm", "Popup", "width=300,height=100");
            popup = window.open(url, "Popup", "width=1024,height=800");

            popup.focus();
            return false
        }


        //-----------------------------------------------------------
        // -------------------------------------------------------
        //-----------------------------------------------------------
// sif imgfolder='' considera carpeta raid mmedia
        //nuevo
        function jsOpenDlgBrowserFld(Control_Id, imgfolder,width)
        {
            var fld = '';
            if (imgfolder !== '') {
                fld = document.getElementById(imgfolder).value;
            }
            var url = "/ckeditor/ImageBrowserFld.aspx?id=" + Control_Id + "&imgfolder=" + fld + "&filter=1&width=" + width;
            popup = window.open(url, "Popup", "width=1024,height=800");
            popup.focus();
            return false
        }

// obsoleto.
        function jsOpenDlgGetImgTaxon(scnidimg, scnidimgurl) {
            var url = "/ckeditor/ImageBrowserFld.aspx?scnidimg=" + scnidimg + "&scnidimgurl=" + scnidimgurl + "&filter=1";
            //var url = "Popup.htm?idName=" + scnidimg
            // popup = window.open("Popup.htm", "Popup", "width=300,height=100");
            popup = window.open(url, "Popup", "width=1024,height=800");

            popup.focus();
            return false
        }


        function jsOpenDlgClearImg(scnidimg, scnidimgurl, noimage) {

            document.getElementById(scnidimg).src = noimage;
            document.getElementById(scnidimgurl).value = noimage;

            return false;
        }


        //-------------------------------------------------------------
        //  - Cuadro de dialogo seleccionar galeria de imagenes
        //------------------------------------------------------------
        function jsOpenChildGallery(scnAUrlImagesTxtId) {

            var url = "/a_dlg/dlgLinkGallery_brw.aspx?scnAUrlImagesTxtId=" + scnAUrlImagesTxtId;

            var popup = window.open(url, "Popup", "width=600,height=600");

            popup.focus();

            return false;
        }
