/*
	Date：2012年6月19日 14:31:08
	Author：Await
	AuthorUrl: http://leotheme.cn/
*/
Util.getName = function(a) {
    return document.getElementsByName(a);
};
Util.getID = function (id){
	return document.getElementById(id);
};
Util.getTag = function (tag) {
	return document.getElementsByTagName(tag);
};
Util.ct = function (txt){
	return document.createTextNode(txt);
};
Util.ce = function (name){
	return document.createElement(name);
};
// 阻止事件冒泡
Util.stopBubble = function(e){
	e.stopPropagation ? e.stopPropagation() : e.cancelBubble = true;
}
// 阻止浏览器默认行为
Util.stopDefault = function(e){
	e.preventDefault ? e.preventDefault() : e.returnValue = false;
}
//获取当前样式
Util.getStyle = function(element){
	return element.currentStyle || document.defaultView.getComputedStyle(element, null);
}
//判断ID是否存在
Util.exid = function(id){
	var o = document.getElementById(id);
	if (o){
		return true;
	}else{
		return false;
	};
};

/*
	绑定事件
	obj	 对像
	type  事件名称
	fn    回调函数
	2011年10月27日 17:02

*/
Util.bind = function (obj, type, fn) {
	if (obj.attachEvent) {
		obj['e' + type + fn] = fn;
		obj[type + fn] = function(){obj['e' + type + fn](window.event);}
		obj.attachEvent('on' + type, obj[type + fn]);
	} else {
		obj.addEventListener(type, fn, false);
	};
}

/*
	移除事件
	obj	 对像
	type  事件名称
	fn    回调函数
	2011年10月27日 17:05
*/
Util.unbind = function (obj, type, fn) {
	if (obj.detachEvent) {
		try {
			obj.detachEvent('on' + type, obj[type + fn]);
			obj[type + fn] = null;
		} catch(_) {};
	} else {
		obj.removeEventListener(type, fn, false);
	};
}

/*
	根据className获取对像
	ele		标签名
	name		class名称
	2011年10月27日 17:05
*/


/*
	判断浏览器及版本
	2011年5月20日 17:01
*/
Util.Browser = function() {
    var a = navigator.userAgent.toLowerCase();
    var b = {};
    b.isStrict = document.compatMode == "CSS1Compat";
    b.isFirefox = a.indexOf("firefox") > -1;
    b.isOpera = a.indexOf("opera") > -1;
    b.isSafari = (/webkit|khtml/).test(a);
    b.isSafari3 = b.isSafari && a.indexOf("webkit/5") != -1;
    b.isIE = !b.isOpera && a.indexOf("msie") > -1;
    b.isIE6 = !b.isOpera && a.indexOf("msie 6") > -1;
    b.isIE7 = !b.isOpera && a.indexOf("msie 7") > -1;
    b.isIE8 = !b.isOpera && a.indexOf("msie 8") > -1;
    b.isGecko = !b.isSafari && a.indexOf("gecko") > -1;
    b.isMozilla = document.all != undefined && document.getElementById != undefined && !window.opera != undefined;
    return b
}();

/*
	获取页面大小相关信息
	get	获取方法 var a = Util.pageSize.get();
	2011年5月25日 17:01
*/
Util.pageSize = {
    get: function() {
        var a = Util.Browser.isStrict ? document.documentElement: document.body;
        var b = ["clientWidth", "clientHeight", "scrollWidth", "scrollHeight"];
        var c = {};
        for (var d in b) c[b[d]] = a[b[d]];
        c.scrollLeft = document.body.scrollLeft || document.documentElement.scrollLeft;
        c.scrollTop = document.body.scrollTop || document.documentElement.scrollTop;
        return c
    }
};

/*
	获取DOM位置信息
	obj		对像
	parent	父级节点
	2011年5月20日17:01
*/
Util.getPosition = function (obj) {
	if(typeof(obj)== "string") obj = Util.getID(obj);
    var c = 0;
    var d = 0;
	var w = obj.offsetWidth;
	var h = obj.offsetHeight;
    do {
        d += obj.offsetTop || 0;
        c += obj.offsetLeft || 0;
        obj = obj.offsetParent
    }
    while (obj)return {
        x: c,
        y: d,
		width: w,
		height: h
    }
};

/*
	计算安全范围
	obj	对像
	2011年5月20日 17:01
*/
Util.safeRange = function( obj ){
	var b = Util.getID(obj);
	var c, d, e, f, g, h, j, k;
	j = b.offsetWidth;
    k = b.offsetHeight;

	p = Util.pageSize.get();
	c = 0;
	e = p.clientWidth - j;
	g = e/2;
	d = 0;
	f = p.clientHeight - k;
	var hc =  p.clientHeight * 0.382 - k/2;
	h = (k < p.clientHeight / 2) ? hc : f/2;
	if (g < 0) g = 0;
	if (h < 0) h = 0;
	//alert(g+"|"+h)
	return {width: j, height: k, minX: c, minY: d, maxX: e, maxY: f, centerX: g, centerY: h};
};

/*
	设定对像位置
	obj		对像
	position	位置
	referID	对像
	2012年3月5日 9:27:43
*/
Util.setXY = function(obj, position, referID, fixed){
	var	p = Util.pageSize.get(), o = Util.safeRange(obj), D = Util.getID(obj);
	if (referID) {
		s = Util.safeRange(referID);
		rp = Util.getPosition(referID);
	}
	var _this = position, st = fixed === true ? 0 : p.scrollTop;
	if (referID != undefined && referID!="") {
		var left = !_this.right ? parseInt(_this.left) : p.clientWidth - s.width - parseInt(_this.right);
		var top = !_this.bottom ? parseInt(_this.top) : p.clientHeight - s.height - parseInt(_this.bottom);
		left1  =	rp.x + parseInt(_this.left);//inside
		left2 =	rp.x + parseInt(_this.left) + s.width;//outside
		right1  =	rp.x + s.width - o.width - parseInt(_this.right);//inside
		right2 =	rp.x - o.width - parseInt(_this.right);//outside
		top1 =	rp.y + parseInt(_this.top);//inside
		top2 =	rp.y + parseInt(_this.top) + s.height;//outside
		bottom1 =	rp.y + s.height - o.height - parseInt(_this.bottom);//inside
		bottom2 = rp.y - o.height - parseInt(_this.bottom);//outside
		left = !_this.right ? (_this.lin ? left1 : left2) : (_this.rin ? right1 : right2);
		top = !_this.bottom ? (_this.tin ? top1 : top2) : (_this.bin ? bottom1 : bottom2);
		D.style.left = left + "px";
		D.style.top = top + "px";
	}
	else{
		if (!_this.left&&!_this.right){
			D.style.left = o.centerX + "px";
		}
		else{
			if (!_this.right){
				D.style.left = parseInt(_this.left) + "px";
			}
			else{
				D.style.right = parseInt(_this.right) + "px";
			};
		};
		if (!_this.top&&!_this.bottom){
			D.style.top = o.centerY + st + "px";
		}
		else{
			if (!_this.bottom){
				D.style.top = parseInt(_this.top) + st + "px";
			}
			else{
				D.style.top = p.clientHeight - D.offsetHeight - parseInt(_this.bottom) + "px";
			};
		};
	};
};

/*
	iframe自适应高度 
	obj	对像
	2011年10月28日 17:01
*/
Util.setIframHeight = function(obj){
	var	fun = function(obj){
		var o = document.getElementById(obj);
		try{
			var a = o.contentWindow.document.body.scrollHeight;
			var b = o.contentWindow.document.documentElement.scrollHeight;
			var h = Math.max(a, b);
			o.height =  h;
		}catch(ex){}
	}
	window.setInterval(fun, 200);
};

//数组原型扩展
Array.prototype.removeRepeat = function(){
	var t, b = [], _i = this.length;
	for(var i=0; i<_i-1; i++){
		for(var j=i+1; j<_i; j++){
			if(this[j] === this[i]){
				this.splice(j,1);
				if(this[i]!==t) t = this[i],b.push(this[i]);
				i--,_i--;
			};
		};
	};
	return b;
};
Array.prototype.min = function(){//最小值
	return Math.min.apply({},this);
};
Array.prototype.max = function(){
	return Math.max.apply({},this);
};
Array.prototype.indexOf = function(val) {
	for (var i = 0;i < this.length;i++) {
		if (this[i] == val) return i;
	};
	return -1;
};
Array.prototype.remove = function(val) {
	var index = this.indexOf(val);
	if (index > -1) {
		this.splice(index, 1);
	};
};

Util.hasClass = function(ele, cls) {
	return ele.className.match(new RegExp('(\\s|^)'+cls+'(\\s|$)'));
};

Util.addClass = function(ele, cls) {
	if (!this.hasClass(ele,cls)) ele.className += " "+cls;
};

Util.removeClass = function (ele, cls) {
	if (hasClass(ele, cls)) {
		var reg = new RegExp('(\\s|^)'+cls+'(\\s|$)');
		ele.className = ele.className.replace(reg,' ');
	}
};

Util.siblings = function(o){
	var a = [];
	var p = o.previousSibling;
	while(p){
		if(p.nodeType===1){
			a.push(p);
		}
		p = p.previousSibling;
	}
	a.reverse();
	var n=o.nextSibling;
	while(n){
		if(n.nodeType===1){
			a.push(n);
		}
		n=n.nextSibling;
	}
	return a;
};

/*
	获取字符串的长度
	obj		对像
	2011年5月20日 17:00:00
*/
Util.getLength= function(obj){
	return obj.replace(/[^\x00-\xff]/g, "**").length;
};

Util.strlen = function(str){
	var len = 0;
	for(var i=0; i<str.length; i++){
		var string = str.substr(i,1);
		if(escape(string).substr(0,2)=="%u"){
			len +=3;
		}else{
			len +=1;
		}
	}
	return len;
}

/*
	写入CSS样式
	val	css内容
	2011年5月20日 16:57:30
*/
Util.addCSS = function( val ){
	var b = this.style;
	if(!b){
		b = this.style = document.createElement('style');
		b.setAttribute('type', 'text/css');
		document.getElementsByTagName('head')[0].appendChild(b);
	};
	b.styleSheet && (b.styleSheet.cssText += val) || b.appendChild(document.createTextNode(val));
};

/*
	载入CSS文件
	path		路径
	name		文件名称
	2011年5月20日 16:57:00
*/
Util.loadCSS = function ( path, name ) {
	if (!path) return;
    var b = Util.getTag('link');
    for (var c in b) {
        if (b[c].href == path) return
    }
    var d = document.createElement("link");
	d.id= name;
    d.rel = "stylesheet";
    d.media = "screen";
    d.type = "text/css";
    d.href = path;
	Util.getTag("HEAD").item(0).appendChild(d);
};

/*
	载入JS文件
	name		文件名
	ocall		加载成功后执行函数 
	ecall		加载出错时执行函数
	chartset	文件编码
	2011年9月30日 16:40:52
*/
Util.loadJS = function( path, ocall, ecall, chartset ) {
    chartset = chartset || 'utf-8';
    var script = document.createElement("script");
    script.charset = chartset;
    script.type = "text/javascript";
	script.id = path;
    script.src = Util.config.JSfile + path + "?" + Util.random("5", false, false);
    var head = Util.getTag('HEAD').item(0);
    if (Util.Browser.isIE) {
        script.onreadystatechange = function() {
            if (! (/loaded|complete/i.test(script.readyState))) return;
            if ('function' == typeof ocall) ocall();
            script.onreadystatechange = null;
            script.parentNode.removeChild(script);
            script = null
        }
    } else {
        script.onload = function() {
            if ('function' == typeof ocall) ocall();
            script.parentNode.removeChild(script);
            script = null
        }
    }
    if ('function' == typeof ecall) script.onerror = function() {
        if ('function' == typeof ecall) ecall();
        script.parentNode.removeChild(script);
        script = null
    };
	head.appendChild(script);
};

/*
	获取随机字符
	length		长度
	upper		是否允许大写字母 
	lower		是否允许小写字母
	number	是否允许数字
	2011年9月30日 16:40:52
*/
Util.random = function( length, upper, lower, number ){
	if( !upper && !lower && !number ){
		upper = lower = number = true;
	}
	var a = [
		["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"],
		["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"],
		["0","1","2","3","4","5","6","7","8","9"]
	];
	//临时数组
	var b = [];
	//临时字串 
	var c = "";
	b = upper ? b.concat(a[0]) : b;
	b = lower ? b.concat(a[1]) : b;
	b = number ? b.concat(a[2]) : b;
	for (var i=0;i<length;i++){ 
		c += b[ Math.round(Math.random()*(b.length-1)) ];
	}
	return c; 
};

/*
	获取URL参数 
	key	参数名称
	url	URL链接，默认为当前URL
	2011年9月30日 16:21:22
*/
Util.getUrlKey = function( key, url ){
	var url = url ? url : location.href;	
	var v = '';
	var o = url.indexOf( key + "=" );
	if (o != -1){
		o += key.length + 1 ;
		e = url.indexOf("&", o);
		if (e == -1){
			e = url.length;
		}
		//v = decodeURIComponent(url.substring(o, e));
		v = url.substring(o, e);
	}
	return v;
};

/*
	固定定位
	obj	对象名称
	2012年01月30日 11:49:25
*/
Util.fixed = function( obj ){
	var o = Util.getID(obj);
	if (!Util.Browser.isIE6) {
		o.style.position = "fixed";
	}else{
		var getClassName = function(ele, name){
			var ele = Util.getTag(ele);
			var arr = [];
			for (var i=0; i<ele.length; i++){
				if (ele[i].className == name){
					arr.push(ele[i]);
				}
			}
			return arr;
		};
		var d = getClassName("div", "ui_dialog_fixed");
		if (Util.getStyle(Util.getID("page"))["backgroundImage"]!="none"){
			Util.addCSS(".ui_dialog_fixed{width:100%; height:1px; position:absolute; z-index: 891201; left:expression(documentElement.scrollLeft+documentElement.clientWidth-this.offsetWidth); top:expression(documentElement.scrollTop)}.body-fixed{background-attachment:fixed;}");
		}else{
			Util.addCSS(".ui_dialog_fixed{width:100%; height:1px; position:absolute; z-index: 891201; left:expression(documentElement.scrollLeft+documentElement.clientWidth-this.offsetWidth); top:expression(documentElement.scrollTop)}.body-fixed{background-attachment:fixed;background-image:url(about:blank);}");
		};
		if(d.length == 0){
			var wrap = Util.ce("div");
			wrap.className = 'ui_dialog_fixed';
			wrap.appendChild(o);
			document.body.appendChild(wrap);
			Util.addClass(Util.getTag("html")[0],"body-fixed");
		}else{
			d[0].appendChild(o);
		};
	};
};

/*
	返回信息类型
	ok		成功
	error		出错
	tips		警告
	2011年5月20日 16:57:05
*/
Util.callBack = {
	ok:function(text){
		return "<div class='ui_box_callback'><span class='ui_box_callback_ok'></span>"+text+"</div>";
	},
	error:function(text){
		return "<div class='ui_box_callback'><span class='ui_box_callback_error'></span>"+text+"</div>";
	},
	tips:function(text){
		return "<div class='ui_box_callback'><span class='ui_box_callback_tips'></span>"+text+"</div>";
	}
};

/*
	Cookie操作
	2012年2月14日 15:10:20
*/
Util.Cookie = {
    get:function(a){
        var b = "";
        var c = a + "=";
		var d = document.cookie;
        if (d.length > 0) {
            g = d.indexOf(c);
            if (g != -1) {
                g += c.length;
                f = d.indexOf(";", g);
                if (f == -1)
                f = d.length;
                b = unescape(d.substring(g, f));
            };
        };
        return b;
    },
    set:function(a, b, d, e){
        var c = "";
		var h = Util.config.cookieHours || 24*30;
        if (h != null) {
            c = new Date((new Date()).getTime() + h * 3600000);
            c = "; expires=" + c.toGMTString();
        };
       document.cookie = a + "=" + escape(b) + c + (d ? "; path=" + d: "; path=/")+ (e ? ";domain=" + e: "")
    },
	del:function(a){
		document.cookie = a + "=;path=/;" + "expires=" + (new Date(0)).toGMTString();
	}
};

/*
	执行动画效果
	obj		要执行动画的对像
	mode	 	动画模式(top, left, fade, default)
	index		index值
	speed		滚动速度(单位：ms)
	tween		缓动效果
	2012年3月3日 8:33:06
*/
Util.animate = function( obj, mode, index, speed, tween){
	var	o = Util.getID(obj),
		Dom = o.children,
		w = Dom[0].offsetWidth,
		h = Dom[0].offsetHeight,
		length = Dom.length,_timer;
	var  t = 0, //当前时间
		b = parseInt(Util.getStyle(Util.getID(obj))[mode]), //初始值
		a = mode == "left" ? -Math.abs(w) * index : -Math.abs(h) * index,
		c = a - b, //变化量
		d = speed; //持续时间
	var run = function(){
		clearTimeout(_timer);
		if (c && t < d) {
			o.style[mode] = Math.round(tween(t++,b,c,d)) + "px";
			_timer = setTimeout(run, 10);
		}else{
			o.style[mode] = a + "px";
		};
	};
	if (mode == "left"){
		Dom[index].style.cssFloat = "left";
		Dom[index].style.display = "block";
		o.style.position = "absolute";
		o.style.width = length*w + "px";
		o.style.height = h + "px";
		return run();
	}else if(mode == "top"){
		Dom[index].style.display = "block";
		o.style.position = "absolute";
		o.style.height = length*h + "px";
		return run();
	}else{
		Dom[index].style.display = "block";
		var s = Util.siblings(Dom[index]);
		//console.log(s+"||"+index)
		for (var i=0; i<s.length; i++){
			//console.log(s[i].innerHTML)
			s[i].style.display = "none";
		}
	};
}
Util.loadCSS(Util.config.JSfile+"core.css");