var app = function() {
	return {
		//JS操作cookies方法!
		//写cookies
		setCookie : function(name, value) {
			var Days = 30;
			var exp = new Date();
			exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
			document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
		},
		//读取cookies
		getCookie : function(name) {
			var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
			if ( arr = document.cookie.match(reg))
				return unescape(arr[2]);
			else
				return null;
		},
		//删除cookies
		delCookie : function(name) {
			var exdate = new Date();
			exdate.setTime(exdate.getTime() - 1);
			var cval = getCookie(name);
			if (cval != null)
				document.cookie = name + "=" + cval + ";expires=" + exdate.toGMTString();
		}
	}
}();
var ui = function() {
	return {
		//选项卡功能
		//tags:选项集合 $("li")
		//tagContents:选项内容集合 $(".tagContents")
		//index:选中的index   <li index="0">
		//classname: 选中对象添加的class名称
		selectTag : function(tags, tagContents, index, classname) {
			// 操作标签
			tags.removeClass(classname);
			tags.each(function(i, element) {
				if (i == index) {
					$(this).addClass(classname);
				}

			});
			// 操作内容
			tagContents.css("display", "none");
			tagContents.each(function(i, element) {
				if (i == index) {
					$(this).css("display", "block");
				}

			});

		}
	}

}();

