if ("\x75\x6edefine\x64"==typeof(RadDockNamespace)){RadDockNamespace=new Object(); }var RadDockableObjectGripFlags= {None: 0,TitleBar: 1,Top: 2,Bottom: 4,Left: 8,Right: 16,All: 31,Auto: 32 } ; RadDockNamespace.V= {v: 0,T: 1,t: 2,S: 3 } ; RadDockNamespace.R= {None: 0,r: 1,Collapse: 2,Close: 4,Pin: 8,Q: 6,Resizable: 7 } ; RadDockNamespace.P= {N: 1,n: 2,M: 4 } ; RadDockNamespace.m= function (L,l){RadDockNamespace.K(L); Object.k(L,RadDockNamespace.J); Object.k(L,RadDockNamespace.H); var i=0; L.h=l[i++]; L.G=l[i++]; L.g=l[i++]; L.F=l[i++]; L.f=l[i++]; L.D=l[i++]; var d=l[i++]; L.ParentDockingZone=d?document.getElementById(d):null; L.C=l[i++]; L.c=l[i++]; var B=l[i++]; L.o0=document.getElementById(l[i++]); L.O0=l[i++]; L.l0=l[i++]; var i0=l[i++]; var I0=l[i++]; var o1=l[i++]; L.O1=document.getElementById(I0); L.l1(B); L.i1(i0); L.I1(); if (!document.readyState || "\143omplete"==document.readyState){RadDockNamespace.o2(L); L.SaveState(); }else if (window.attachEvent){var O2= function (){RadDockNamespace.o2(L); L.SaveState(); } ; window.attachEvent("\x6fnloa\x64",O2); }L.o0.cells[0].style.height=document.all?"100%": ""; var l2=["\x54\x69tlebar\x43\145l\x6c","\x54\x69tleCel\x6c","Horiz\x6f\x6etalGri\x70\x43ell\x31","Horizontal\x47\x72ipC\x65\x6cl2","\x56\145\x72\x74ical\x47\x72ipC\x65\154\x6c\x31","Ver\x74\x69calGri\x70\x43ell2"]; for (var i=0; i<l2.length; i++){var i2=l2[i]; var I2=document.getElementById(L.id+"\x5f"+i2); if (I2!=null){RadDockNamespace.o3(I2,"\x64ragsta\x72\x74",new Function("\x72et\x75\x72n fals\x65")); I2.setAttribute("\x75nselectabl\x65","\x6f\156"); }}if ("\x73trin\x67"==typeof(o1) && o1.indexOf("(")==-1 && o1.indexOf("\x29")==-1){L.AddEventHandler("\x44ockStateCha\x6e\x67ed",eval(o1)); }if (L.O3()){if (!L.l3()){L.Pin(); }else {L.i3= true; }}} ; RadDockNamespace.J= {IsDockableObject: true ,I3:function (index){return ((this.O0&index)>0); } ,o4:function (index,value){var O4=this.O0; if (value){ this.O0 |= index; }else { this.O0 &= ~index; }if (O4!=this.O0){ this.l4(); this.SaveState(); }} ,l4:function (){var i4=this.IsDocked(); var I4=this.I3(RadDockNamespace.P.N); var o5=this.GetCommandByName("\x43\x6fllapse"); if (o5){o5.Enable(I4); }var O5=this.GetCommandByName("\x45xpand"); if (O5){O5.Enable(!I4); }var l5=this.I3(RadDockNamespace.P.n); i5=this.GetCommandByName("\x55npin"); if (i5){i5.Enable(!i4 && l5); }i5=this.GetCommandByName("P\x69\x6e"); if (i5){i5.Enable(!i4 && !l5); }i5=this.GetCommandByName("\103\x6c\x6fse"); if (i5){i5.Enable( true); }} ,I5:function (){return this.I3(RadDockNamespace.P.N); } ,O3:function (){return this.I3(RadDockNamespace.P.n); } ,l3:function (){return this.I3(RadDockNamespace.P.M); } ,o6:function (){var O6=this.IsVisible(); this.o4(RadDockNamespace.P.M,!O6); if (O6){ this.I1(); }if (O6 && this.i3){ this.Pin(); this.i3=null; }} ,l6:function (){if (null!=this.i6){for (var i=0; i<this.i6.length; i++){ this.i6[i]=null; }} this.i6=null; this.ParentDockingZone=null; this.TitleBar=null; this.TopGrip=null; this.BottomGrip=null; this.LeftGrip=null; this.RightGrip=null; this.o0=null; this.I6=null; this.c=null; this.C=null; } ,SaveState:function (){var o7=new Array(); var width=(this.IsVisible()?this.offsetWidth: this.O7); var height=(this.IsVisible()?this.offsetHeight: this.l7); o7[o7.length]=this.style.top; o7[o7.length]=this.style.left; o7[o7.length]=(width+"p\x78"); o7[o7.length]=(this.I5()?(height+"\x70\x78"): this.l0); o7[o7.length]=this.O0; o7[o7.length]=this.style.zIndex; o7[o7.length]=(this.ParentDockingZone?this.ParentDockingZone.G: ""); var i7=new Array(); var I7=this.i6; var i5; for (var i=0; i<I7.length; i++){i5=I7[i]; var o8=new Array(); o8[o8.length]=i5.Name; o8[o8.length]=i5.IsEnabled(); o8[o8.length]= true; i7[i7.length]=o8.join("!"); }o7[o7.length]=i7.join("\x7c"); this.O1.value=o7.join(","); } ,IsDocked:function (){return ((this.F&RadDockNamespace.V.T)>0 && this.ParentDockingZone!=null); } ,O8:function (){return ((this.F&RadDockNamespace.V.t)>0 && this.ParentDockingZone==null); } ,l8:function (){return ((this.F&RadDockNamespace.V.t)>0); } ,CanResize:function (){return ((this.g&RadDockNamespace.R.r)>0); } ,i8:function (I8){if (!I8)return false; if (0==(this.F&RadDockNamespace.V.T))return false; if (RadDockingZoneTypeFlags.Custom==this.f){var o9=I8.id; var O9=this.D; for (var i=0; i<O9.length; i++){if (o9==O9[i])return true; }return false; }else {return ((this.f&I8.Type)>0); }} ,DockTo:function (I8,position){if (!I8)return; if (!this.i8(I8))return; I8.l9(this ); this.i9(); } ,I9:function (){ this.ParentDockingZone=null; this.parentNode.removeChild(this ); var parentNode=document.getElementsByTagName("\106ORM")[0]; parentNode=parentNode?parentNode:document.body; parentNode.appendChild(this ); this.oa(); } ,i9:function (fireEvent){ this.I1(); this.Oa(); this.SaveState(); var i5=this.GetCommandByName("\x50in"); if (i5){i5.Enable( false); }i5=this.GetCommandByName("U\x6e\x70in"); if (i5){i5.Enable( false); }if ( false !=fireEvent){ this.la("DockStateC\x68\x61nge\x64", {docked: true } ); }} ,ia:function (){ this.I1(); this.Oa(); var i5=this.GetCommandByName("\x50in"); if (i5){i5.Enable(!this.O3()); }i5=this.GetCommandByName("\x55npin"); if (i5){i5.Enable(this.O3()); }if (this.Ia || this.ob){ this.SetSize(this.Ia,this.ob); this.Ia=null; this.ob=null; } this.SaveState(); this.la("D\x6f\x63kState\x43\150a\x6e\x67e\x64", {docked: false } ); } ,I1:function (){if (this.l3())return; if (!this.h){if (!document.all){ this.style.setProperty("cl\x65\x61r","b\x6f\x74h",""); }return; }if (this.IsDocked()){ this.style.position=""; this.style.display=""; if (document.all){ this.style.display="inline"; }else { this.style.setProperty("\x66loat","left",""); }}else { this.style.position="\x61bsolute"; if (document.all){ this.style.display=""; }else { this.style.setProperty("\x66loat","",""); this.style.setProperty("\x63\x6cear","both",""); }}} ,l1:function (Ob){ this.TitleBar=null; this.TopGrip=null; this.BottomGrip=null; this.LeftGrip=null; this.RightGrip=null; if (!Ob || !Ob.length)return; var lb=0; this.TitleBar=document.getElementById(Ob[lb++]); this.TopGrip=document.getElementById(Ob[lb++]); this.BottomGrip=document.getElementById(Ob[lb++]); this.LeftGrip=document.getElementById(Ob[lb++]); this.RightGrip=document.getElementById(Ob[lb++]); } ,SetGripVisible:function (ib,visible){if (ib){ib.style.display=(visible?"": "none"); }} ,IsGripVisible:function (ib){return (ib.style.display!="none"); } ,Oa:function (){ this.SetGripVisible(this.TitleBar,this.Ib(RadDockableObjectGripFlags.TitleBar)); this.SetGripVisible(this.TopGrip,this.Ib(RadDockableObjectGripFlags.Top)); this.SetGripVisible(this.BottomGrip,this.Ib(RadDockableObjectGripFlags.Bottom)); this.SetGripVisible(this.LeftGrip,this.Ib(RadDockableObjectGripFlags.Left)); this.SetGripVisible(this.RightGrip,this.Ib(RadDockableObjectGripFlags.Right)); } ,Ib:function (oc){var Oc; if (this.IsDocked()){Oc=this.c; if (RadDockableObjectGripFlags.Auto==Oc){switch (this.ParentDockingZone.Type){case RadDockingZoneTypeFlags.Top:case RadDockingZoneTypeFlags.Bottom:case RadDockingZoneTypeFlags.Left:case RadDockingZoneTypeFlags.Right:return (oc==RadDockableObjectGripFlags.TitleBar); case RadDockingZoneTypeFlags.Horizontal:return (oc==RadDockableObjectGripFlags.Left); case RadDockingZoneTypeFlags.Vertical:return (oc==RadDockableObjectGripFlags.Top); default:return false; }}}else {Oc=this.C; if (RadDockableObjectGripFlags.Auto==Oc){return (oc==RadDockableObjectGripFlags.TitleBar); }}return ((Oc&oc)>0); } ,lc:function (){return ((this.g&RadDockNamespace.R.Collapse)>0); } ,Expand:function (ic){if (null==ic){ic= true; }if (ic==this.I5()){return; }if (!ic && this.I5()){ this.l0=(this.offsetHeight+"\x70\170"); }else {if (RadDockNamespace.O.w){ this.l0=((parseInt(this.l0)-this.offsetHeight)+"\x70x"); }} this.o4(RadDockNamespace.P.N,ic); if (this.I6.Ic){var od=this.o0; var Od=od.cells[0]; var ld=this ; var oe= function (){Od.firstChild.style.display="\x6eone"; od.style.display=""; } ; var Oe= function (){if (ic){Od.firstChild.style.display=""; Od.firstChild.style.height="100%"; }od.style.display=ic?"": "\x6eone"; ld.SaveState(); } ; var le=this.GetRect(); new RadEffect.r( {object: this,height:ic?this.l0: this.GetRect(this.TitleBar).height,width:le.width,oe:oe,Oe:Oe,ie: 1/3 } ); }else { this.o0.style.display=ic?"": "none"; this.style.height=ic?(parseInt(this.l0)+"\x70x"): "\x31"; this.SaveState(); }} ,Collapse:function (){ this.Expand( false); } ,Pin:function (){var le=this.GetRect(); var offsetLeft=le.left;var offsetTop=le.top;var Ie=this ; var of= function (){Ie.MoveTo(RadDockNamespace.Of()+offsetLeft,RadDockNamespace.If()+offsetTop); Ie.SaveState(); } ; this.og=setInterval(of,10); this.o4(RadDockNamespace.P.n, true); } ,Unpin:function (){clearInterval(this.og); this.og=null; this.o4(RadDockNamespace.P.n, false); } ,i1:function (Og){ this.i6=new Array(); this.lg=new Array(); var ig,Ig,id; for (var i=0; i<Og.length; i++){ig=Og[i]; id=ig[0]; Ig=document.getElementById(id); if (Ig){ig.splice(0,1); RadDockNamespace.oh(Ig,this,ig); this.i6[this.i6.length]=Ig; var Oh=RadDockNamespace.lg[Ig.Name]; if (Oh && !Ig.OnCommand){Ig.OnCommand=Oh; }}}} ,GetCommandByName:function (lh){var i5; for (var i=0; i<this.i6.length; i++){i5=this.i6[i]; if (i5 && i5.Name==lh){return i5; }}return null; } ,ih:function (Ih,oi){Ih.Expand(); } ,Oi:function (Ih,oi){Ih.Collapse(); } ,ii:function (Ih,oi){Ih.Pin(); } ,Ii:function (Ih,oi){Ih.Unpin(); } ,oj:function (Ih,oi){Ih.Hide(); }} ; RadDockNamespace.lg=[]; RadDockNamespace.lg["\x45\x78pand"]=RadDockNamespace.J.ih; RadDockNamespace.lg["\103\x6f\x6clapse"]=RadDockNamespace.J.Oi; RadDockNamespace.lg["\x43\x6cose"]=RadDockNamespace.J.oj; RadDockNamespace.lg["Pin"]=RadDockNamespace.J.ii; RadDockNamespace.lg["Unpin"]=RadDockNamespace.J.Ii;
