if ("u\x6e\x64efined"==typeof(RadDockNamespace)){RadDockNamespace=new Object(); }RadDockNamespace.ll=null; RadDockNamespace.il=null; RadDockNamespace.Il=null; RadDockNamespace.om=null; RadDockNamespace.Om=null; RadDockNamespace.Im=""; RadDockNamespace.On=0; RadDockNamespace.In=0; RadDockNamespace.oo= false; RadDockNamespace.Oo= function (ok){if (!ok){ok=window.event; }if (RadDockNamespace.ll){RadDockNamespace.Io(ok); RadDockNamespace.oo= true; }else if (!this.op){var Op=RadDockNamespace.lp(ok); RadDockNamespace.Om=Op?Op.ip:null; RadDockNamespace.Im=Op?Op.action:null; RadDockNamespace.Ip(RadDockNamespace.Im); }} ; RadDockNamespace.oq= function (ok){if (!ok){ok=window.event; }if (RadDockNamespace.Om){RadDockNamespace.Oq(RadDockNamespace.Om,ok); if (ok.preventDefault){ok.preventDefault(); }ok.returnValue= false; }} ; RadDockNamespace.lq= function (ok){if (!ok){ok=window.event; }if (RadDockNamespace.ll){RadDockNamespace.iq(ok); }} ; RadDockNamespace.Iq= function (ok){if (!ok){ok=window.event; }if (27==ok.keyCode){if (RadDockNamespace.ll)RadDockNamespace.or(ok); if (this.op){ this.op.Or(); }}} ; RadDockNamespace.Oq= function (lr,ok){RadDockNamespace.oo= false; RadDockNamespace.ll=lr; RadDockNamespace.On=ok.clientX; RadDockNamespace.In=ok.clientY; if (RadDockNamespace.ll.O8()){RadDockNamespace.ll.oa(); }} ; RadDockNamespace.iq= function (ok){if (RadDockNamespace.oo){RadDockNamespace.oo= false; var ir=RadDockNamespace.ll; var Ir=ir.I6.Ic; if (Ir){RadDockNamespace.os(ok); }else {RadDockNamespace.Os(ok); }}RadDockNamespace.or(ok); } ; RadDockNamespace.Os= function (ok){var ls=RadDockNamespace.il; var ir=RadDockNamespace.ll; var is=ir.ParentDockingZone; var Is,ot; if (ls){ls.l9(ir); Is=ir; }else if (RadDockNamespace.Il){var le=RadDockNamespace.Il.GetRect(); if ("m\x6fve"==RadDockNamespace.Im && ir.IsDocked()){if (!ir.l8()){return; }ir.I9(); ot=ir; }ir.SetRect(le); }ir.SaveState(); if (is){is.SaveState(); }if (Is){Is.i9(); }else if (ot){ot.ia(); }Is=null; ot=null; } ; RadDockNamespace.os= function (ok){var ls=RadDockNamespace.il; var ir=RadDockNamespace.ll; var action=RadDockNamespace.Im; var is=ir.ParentDockingZone; var Is,ot; var Ot,lt,it; var It,ou; It=ir.GetRect(); if ("move"==action && ir.ParentDockingZone){Ot=RadDockNamespace.Ou(ir, false); }if (ls){ls.l9(ir); ir.i9( false); Is=ir; ou=ir.GetRect(); lt=RadDockNamespace.Ou(ir, true); it=ir.cloneNode(3); document.body.appendChild(it); it.style.position="abso\x6c\x75\164\x65"; it.style.display=""; it.GetRect=ir.GetRect; it.SetRect=ir.SetRect; it.SetSize=ir.SetSize; it.MoveTo=ir.MoveTo; ir.style.display="\x6e\x6fne"; }else {if ("move"==action && ir.IsDocked()){if (!ir.l8()){if (Ot){Ot.parentNode.removeChild(Ot); Ot=null; }return; }ir.I9(); ot=ir; }it=ir; ou=RadDockNamespace.Il.GetRect(); }if ("m\x6fve"==action){it.SetRect(It); }var i=0; var lu=new Array(); if (Ot){lu[i++]=new RadEffect.r( {object:Ot,width: 0,height: 0,iu: true } ); }if (lt){lu[i++]=new RadEffect.r( {object:lt,width:ou.width,height:ou.height,iu: true } ); }if (!("\x6dove"!=action && ir.ParentDockingZone)){lu[i++]=new RadEffect.MoveTo( {object:it,Iu:ou.left,ov:ou.top,iu: true } ); }if ("move"!=action){lu[i++]=new RadEffect.r( {object:it,width:ou.width,height:ou.height,iu: true } ); }var ld=this ; var Ov= function (){if (Ot){Ot.parentNode.removeChild(Ot); Ot=null; }if (lt){lt.parentNode.removeChild(lt); lt=null; }if (it && it!=ir){it.parentNode.removeChild(it); it=null; }if (Is){Is.i9(); }else if (ot){ot.ia(); }if (is){is.SaveState(); is=null; }if (ls){ls.SaveState(); ls=null; }ir.SaveState(); Is=null; ot=null; ld.op=null; RadDockNamespace.Ip("\x64e\x66\x61ult"); } ; var lv=ir.I6; this.op=new RadEffect.iv( {Iv:lv.ow,ie:lv.Ow,oe:function (){RadDockNamespace.Ip("wait"); } ,Oe:Ov,lu:lu } ); } ; RadDockNamespace.Ou= function (Ih,lw){var iw; if (document.all){iw=document.createElement("s\x70an"); }else {iw=document.createElement("ta\x62\x6ce"); iw.insertRow(0).insertCell(0); }var le=Ih.GetRect(); iw.style.width=(lw?0:le.width)+"\x70x"; iw.style.height=(lw?0:le.height)+"\x70x"; iw.style.font="\x6e\157\x72\x6dal 1\x70\x78 ar\x69al"; Ih.parentNode.insertBefore(iw,Ih); return iw; } ; RadDockNamespace.or= function (ok){RadDockNamespace.Iw(); if (RadDockNamespace.il){RadDockNamespace.il.ox( false); }RadDockNamespace.ll=null; RadDockNamespace.il=null; RadDockNamespace.On=null; RadDockNamespace.In=null; if (RadDockNamespace.om){RadDockNamespace.om.Hide(); RadDockNamespace.om=null; }} ; RadDockNamespace.Io= function (ok){var Ox=ok.clientX-RadDockNamespace.On; var lx=ok.clientY-RadDockNamespace.In; var ir=RadDockNamespace.ll; var lv=ir.I6; if (!RadDockNamespace.Il){RadDockNamespace.Il=RadDockNamespace.ix(ir); }if (lv.Ix && !RadDockNamespace.om){RadDockNamespace.om=RadDockNamespace.oy(ir); }var Oy=RadDockNamespace.Il; if ("\155\x6fve"==RadDockNamespace.Im){Oy.MoveBy(Ox,lx); var ly=Oy.GetRect(); RadDockNamespace.il=lv.iy(ir,ok,ly); RadDockNamespace.Iy(ly); RadDockNamespace.oz(ok,ly, true); }else {var Oz=Oy.childNodes[0]; if (Oz){Oz.style.width="\061\x70x"; Oz.style.height="\x31px"; }Oy.r(RadDockNamespace.Im,Ox,lx); var ly=Oy.GetRect(); if (Oz){Oz.style.width=ly.width+"px"; Oz.style.height=ly.height+"px"; RadDockNamespace.o2(Oz); }RadDockNamespace.oz(ok,ly, false); }RadDockNamespace.On=ok.clientX; RadDockNamespace.In=ok.clientY; } ; RadDockNamespace.oz= function (ok,lz,iz){var Iz=RadDockNamespace.om; if (Iz){if (iz){Iz.o10("\x28"+lz.left+"\x2c"+lz.top+"\x29"); }else {Iz.o10("("+lz.width+" x "+lz.height+"\x29"); }var x=ok.clientX+5+RadDockNamespace.Of(); var y=ok.clientY+5+RadDockNamespace.If(); Iz.O10(x,y); }} ; RadDockNamespace.ix= function (Ih){var l10=Ih.I6; var Oy=l10.i10; if (!Oy)return null; Oy.innerHTML=""; if (l10.I10){var le=Ih.GetRect(); var o11=Ih.cloneNode( true); o11.style.position=""; o11.style.display=""; Oy.appendChild(o11); }Oy.style.position="absolute"; Oy.Show(); Oy.SetRect(Ih.GetRect()); Oy.oa(); return Oy; } ; RadDockNamespace.oy= function (Ih){var O11=Ih.I6.l11; if (!O11)return null; O11.oa(); return O11; } ; RadDockNamespace.Iw= function (){var Oy=RadDockNamespace.Il; if (Oy){Oy.Hide(); Oy.innerHTML=""; }RadDockNamespace.Il=null; } ; RadDockNamespace.lp= function (ok){var ip=null; var action=""; var srcElement=RadDockNamespace.i11(ok); switch (srcElement.className){case "\x52\x61\x64Dock\x61\x62leOb\x6a\145\x63\164R\x65\x73iz\x65\x61b\x6ce":action="resize"; break; case "\x52\x61dDock\x61\x62leO\x62\x6aect\x54\x69tle\x42\x61r":case "Ra\x64\x44ockable\x4f\x62jec\x74\124it\x6c\x65":case "\x52adDockab\x6c\x65Obje\x63\x74Hor\x69\x7aont\x61\x6cGri\x70":case "RadDocka\x62\x6ceObj\x65\x63tVer\x74\151ca\x6c\107ri\x70":action="\x6d\x6fve"; break; default:return null; }ip=RadDockNamespace.I11(srcElement); if (!ip)return null; if (ip.O3())return null; if (ip.F==RadDockNamespace.V.v)return null; if (ip.ParentDockingZone && !ip.ParentDockingZone.o12){return null; }if ("\x72esize"==action){if (!ip.I5())return null; if (!ip.CanResize())return null; var O12=ip.ParentDockingZone; if (O12 && O12.l12)return null; action=ip.i12(ok); }return {ip:ip,action:action } ; } ; RadDockNamespace.I11= function (L){var node=L; while (node && node.parentNode){switch (node.className){case "RadDockab\x6c\x65Obj\x65\x63tRe\x73izeable":case "\x52adDockableOb\x6a\x65ctF\x69\x78ed":return (node.IsDockableObject?node:null); }node=node.parentNode; }return null; } ; RadDockNamespace.Ip= function (cursor,L){if (!cursor)cursor=""; if (!L || !L.style){L=document.body; }if (L.style.cursor!=cursor){L.style.cursor=cursor; }} ; RadDockNamespace.Iy= function (lz){var I12=0; var o13=RadDockNamespace.If(); var O13=(document.body.clientHeight+o13); if (lz.top<o13){I12=-((o13-lz.top)+1); }else if (lz.bottom>O13){I12=(lz.bottom-O13)+1; }var l13=0; var i13=RadDockNamespace.Of(); var I13=(document.body.clientWidth+i13); if (lz.left<i13){l13=-((i13-lz.left)+1); }else if (lz.right>I13){l13=(lz.right-I13)+1; }window.scrollBy(l13,I12); } ; RadDock_GetDockingZone= function (id){var el=document.getElementById(id); return (el.IsDockingZone?el:null); };RadDock_GetDockableObject= function (id){var el=document.getElementById(id); return (el.IsDockableObject?el:null); };