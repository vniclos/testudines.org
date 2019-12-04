<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialogmodal.aspx.cs" Inherits="testudines.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/a_scripts/jquery-1.10.2.js"></script>
    <script src="/a_scripts/bootstrap.js"></script>
    <link href="/a_css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
          <!-- /.modal -->
    <div class="container">
        <h2>Bootstrap 3.3.7 - Modal Demo</h2>

        <div class="row text-center">
            <h3>The Basic Modal</h3>
            <a href="#" class="btn btn-lg btn-success" data-toggle="modal" data-target="#basicModal">Click to open Modal</a>
        </div>
        <hr>
        <div class="row text-center">
            <h3>The Large Modal</h3>
            <a href="#" class="btn btn-lg btn-primary" data-toggle="modal" data-target="#largeModal">Click to open Modal</a>
        </div>
        <hr>
        <div class="row text-center">
            <h3>The Small Modal</h3>
            <a href="#" class="btn btn-lg btn-danger" data-toggle="modal" data-target="#smallModal">Click to open Modal</a>
        </div>

    </div>

    <div class="modal fade" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Basic Modal</h4>
                </div>
                <div class="modal-body">
                    <h3>Modal Body</h3>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="largeModal" tabindex="-1" role="dialog" aria-labelledby="largeModal" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Large Modal</h4>
                </div>
                <div class="modal-body">
                    <h3>Modal Body</h3>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="smallModal" tabindex="-1" role="dialog" aria-labelledby="smallModal" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Small Modal</h4>
                </div>
                <div class="modal-body">
                    <h3>Modal Body</h3>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <p class="p">Demo by Syed Fazle Rahman. <a href="http://www.sitepoint.com/understanding-bootstrap-modals/" target="_blank">See article</a>.</p>
    <!-- /.modal fin -->
    </form>
</body>
</html>
