function ExtendMenuWithKeyboard(){if ((typeof(RadMenu)=="undefin\x65\x64") || (typeof(RadMenu.KeyDown)!="\x75\x6edefin\x65\x64")){return; }RadMenu.prototype.l2p= function (){var i2p=0; for (var i=0; i<this.GroupStateManagement.length; i++){if ((this.GroupStateManagement[i]!=null) && (i2p<i)){i2p=i; }}return i2p; };RadMenu.prototype.I2p= function (o2q){if (o2q!=0){return this.GetGroup(this.GroupStateManagement[o2q]); }else {return this.RootGroup; }};RadMenu.prototype.O2q= function (l2q){if (this.i11.Ig(l2q)){if (this.i11.Ig(l2q.I19)){return l2q.I19; }else if (this.i11.Ig(l2q.i17) && this.i11.Ig(l2q.i17[0])){return l2q.i17[0]; }}return null; };RadMenu.prototype.i2q= function (l2q){if (this.i11.Ig(l2q)){if (this.i11.Ig(l2q.I19)){return true; }else if (this.i11.Ig(this.RootGroup.I19)){return true; }}return false; };RadMenu.prototype.I2q= function (o2r){var O2r=o2r.ChildGroup; if (O2r && O2r.ID){ this.GroupStateManagement[o2r.Level+1]=O2r.ID; O2r.Show(o2r.Container); this.l2r(O2r.i17[0]); return true; }else {return false; }};RadMenu.prototype.i2r= function (){var I2r="i"; for (var i=0; i<this.l1y.length; i++){I2r+=this.l1y[i]; }return I2r; };RadMenu.prototype.o2s= function (){if (this.i11.Ig(this.I1y)){ this.O1z="\151"; if (this.i11.Ig(this.I14)){ this.O1z+=this.I14; }if (this.i11.Ig(this.i14)){ this.O1z+=this.i14; } this.O1z+=this.I1y; }};RadMenu.prototype.O2s= function (){return this.O1y.l17(this.i2r()); };RadMenu.prototype.KeyUp= function (processedEvent){if (!processedEvent){var processedEvent=window.event; }var l2s=this.i11.oj(processedEvent); var Ic=this.O2s(); if (Ic){Ic.RemoveState(MODE_CLICKED); }if (l2s==l2k){var i2s=this.l2p(); if (i2s>0){i2s-=1; }var I2s=this.I2p(i2s); var o2t=this.O2q(I2s); o2t.RemoveState(MODE_CLICKED); o2t.Render(MODE_HILIGHT); } this.l1y.pop(); } ; RadMenu.prototype.KeyDown= function (processedEvent){if (!processedEvent){var processedEvent=window.event; }var O2t=this.i11.Ih(processedEvent); if (O2t.type=="\x74ext" || O2t.type=="textarea"){return; }var l2s=this.i11.oj(processedEvent); var l2t= false; var i2s=this.l2p(); var I2s=this.I2p(i2s); var o2t=this.O2q(I2s); if (this.O1z==""){ this.o2s(); }for (var i=0; i<this.l1y.length; i++){if (this.l1y[i]==l2s){l2t= true; switch (l2s){case l2l:case i2l:case O2l:case o2l:case O2m:case l2k:case l2m:break; default:return; }}}if (!l2t){ this.l1y.push(l2s); }if (this.O1z==this.i2r()){if (this.O19== false){ this.O19= true; this.i2t(processedEvent); }else { this.O19= false; this.I2t(processedEvent); }return false; }var Ic=this.O2s(); if (Ic){if (this.O19== false){ this.O19= true; this.o2u(Ic); }if (this.I2q(Ic)){Ic.ApplyClick(processedEvent); Ic.RemoveClick(processedEvent); }return false; }if (!this.i2q(I2s)){return; }switch (l2s){case l2l:case i2l:case O2l:case o2l:case l2m: this.i11.Ok(processedEvent); break; }if (this.O19== true){var i2s=this.l2p(); var I2s=this.I2p(i2s); var o2t=this.O2q(I2s); if (l2s==O2m){ this.CloseAll((i2s-1)); if ((i2s-1)==0){ this.O19= false; }return false; }if (l2s==l2m){o2t.i18(processedEvent); o2t.l18(processedEvent); }if (l2s==l2k){if (o2t.Enabled!= true){return; }if (!this.I2q(o2t)){o2t.ApplyClick(processedEvent); o2t.RemoveClick(processedEvent); }return false; } this.l2r(this.O2u(o2t,I2s,i2s,l2s)); return false; }return true; } ; RadMenu.prototype.i2t= function (processedEvent){if (this.ClickToOpen== false){ this.ClickToOpen= true; this.FirstClick= false; }if (this.RootGroup && this.RootGroup.i17 && this.RootGroup.i17.length>0){ this.l2r(this.RootGroup.i17[0]); }};RadMenu.prototype.o2u= function (item){if (this.ClickToOpen== false){ this.ClickToOpen= true; this.FirstClick= false; }if (this.RootGroup && this.RootGroup.i17 && this.RootGroup.i17.length>0){ this.l2r(item); }};RadMenu.prototype.I2t= function (processedEvent){if (this.ClickToOpen== true){ this.ClickToOpen= false; this.FirstClick= true; } this.CloseAll(0); window.status=""; };RadMenu.prototype.l2r= function (l24){if (l24){var ParentGroup=null; var o1a=0; ParentGroup=l24.ParentGroup; o1a=l24.Level; if ((o1a)>0 && (ParentGroup!=null)){if (this.GroupStateManagement[o1a]!=ParentGroup.ID){ this.GroupStateManagement[o1a]=ParentGroup.ID; }if (ParentGroup.Visible!= true){ParentGroup.Show(ParentGroup.O11.Container); }} this.l2u(l24); }};RadMenu.prototype.l2u= function (l24){ this.I18(this.o19); this.CloseAll(l24.Level); if (l24==(l24.ParentGroup.I19)){return; }if (l24.ParentGroup){if (l24.ParentGroup.I19!=null){l24.ParentGroup.I19.RemoveHilight(); }l24.ParentGroup.I19=l24; }if (!this.i11.Ig(l24.I15)){l24.ApplyHilight(); }} ; RadMenu.prototype.NextItem= function (i2u){if (i2u.NextItem){if (i2u.NextItem.i16){return this.NextItem(i2u.NextItem); }return i2u.NextItem; }else {return this.I2u(i2u.ParentGroup); }};RadMenu.prototype.PreviousItem= function (i2u){if (i2u.PreviousItem){if (i2u.PreviousItem.i16){return this.PreviousItem(i2u.PreviousItem); }return i2u.PreviousItem; }else {return this.o2v(i2u.ParentGroup); }};RadMenu.prototype.I2u= function (O2v){if (O2v && O2v.i17){if (O2v.i17[0].i16){return this.NextItem(O2v.i17[0]); }return O2v.i17[0]; }return null; };RadMenu.prototype.o2v= function (O2v){if (O2v && O2v.i17){if (O2v.i17[(O2v.i17.length-1)].i16){return this.PreviousItem(O2v.i17[(O2v.i17.length-1)]); }return O2v.i17[(O2v.i17.length-1)]; }return null; };RadMenu.prototype.O2u= function (I2c,i2c,l2v,i2v){if (!this.i11.Ig(I2c) || !this.i11.Ig(i2c) || !this.i11.Ig(l2v)){return null; }var I2v=i2c.l1f; switch (i2v){case l2l:if (I2v==VERTICAL_DIRECTION){return this.PreviousItem(I2c); }else if (I2c.ChildGroup){return this.I2u(I2c.ChildGroup); }break; case i2l:if (I2v==VERTICAL_DIRECTION){return this.NextItem(I2c); }else if (I2c.ChildGroup){return this.I2u(I2c.ChildGroup); }break; case O2l:if (I2v==VERTICAL_DIRECTION){if (I2c.ChildGroup){return this.I2u(I2c.ChildGroup); }else {var o2w= true; if ((l2v-1)<0){return null; }i2c=this.I2p(l2v-1); if (i2c.l1f==VERTICAL_DIRECTION){for (var i=this.GroupStateManagement.length; i>=0; i--){if (this.GroupStateManagement[i]){i2c=this.GetGroup(this.GroupStateManagement[i]); if (i2c.l1f==HORIZONTAL_DIRECTION){o2w= false; break; }}}if (o2w){i2c=this.RootGroup; }}return this.NextItem(i2c.I19); }}else {return this.NextItem(I2c); }break; case o2l:if (I2v==VERTICAL_DIRECTION){if ((l2v-1)<0){return null; }i2c=this.I2p(l2v-1); if (i2c.l1f==VERTICAL_DIRECTION){return i2c.I19; }else {return this.PreviousItem(i2c.I19); }}else {return this.PreviousItem(I2c); }break; default:return; }};}
