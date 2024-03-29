﻿
/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

//CKEDITOR.editorConfig = function( config )
//{
//	// Define changes to default configuration here. For example:
//	// config.language = 'fr';
//	// config.uiColor = '#AADC6E';
//};



CKEDITOR.editorConfig = function (config) {
    customConfig: '/scripts/ckeditor/config.js';

    // Disables the built-in spell checker while typing natively available in the browser (currently Firefox and Safari only).
    config.disableNativeSpellChecker = true;

    // If enabled (true), turns on SCAYT (SpellCheckAsYouType) automatically after loading the editor.
    config.scayt_autoStartup = false;
    config.scayt_sLang = 'es_ES';

    config.filebrowserImageBrowseUrl = '/ckeditor/ImageBrowser.aspx';
    config.filebrowserImageWindowWidth = 980;
    config.filebrowserImageWindowHeight = 980;
    config.filebrowserBrowseUrl = '/ckeditor/LinkBrowser.aspx';
    config.filebrowserWindowWidth = 500;
    config.filebrowserWindowHeight = 650;

    config.resize_maxWidth = 600;
    config.htmlEncodeOutput = false;
    config.entities = false;
    config.entities_greek = false;
    config.format_tags = "p;h3;h4;pre;address";
    config.toolbar = 'Basic';
  
        // ckeditor_config.js'

    config.toolbar_Full =
        [
            { name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'] },
            { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
            { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'] },
            {
                name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton',
                    'HiddenField']
            },
            '/',
            { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
            {
                name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv',
                    '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl']
            },
            { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
            { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
            '/',
            { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
            { name: 'colors', items: ['TextColor', 'BGColor'] },
            { name: 'tools', items: ['Maximize', 'ShowBlocks', '-', 'About'] }
        ];

    config.toolbar_Basic =
        [
            ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', '-', 'RemoveFormat', 'Format', 'TextColor', 'Preview', 'Source', '-', 'SpecialChar', 'Subscript', 'Superscript', 'Image', 'Outdent', 'Indent', 'Templates', 'SpellChecker', 'Scayt']
        ];
};