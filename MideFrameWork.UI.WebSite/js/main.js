var meg = {};

meg.tools = {};

meg.ui = {};
//给文本框添加label提示
meg.ui.funPlaceholder = function(element) {
	//检测是否需要模拟placeholder
	var default_txt = '';
	if (element && ( default_txt = element.attr("default_txt"))) {
		//当前文本控件是否有id, 没有则创建
		var idLabel = element.attr("id");
		if (!idLabel) {
			idLabel = "default_txt_" + new Date().getTime();
			element.id = idLabel;
		}

		//创建label元素
		var eleLabel = $("<label></label>");
		eleLabel.attr("for", idLabel);
		eleLabel.css({
			"position" : "absolute",
			"cursor" : "text"
		});
		eleLabel.offset(element.position());
		//插入创建的label元素节点
		element.before(eleLabel, element);
		//事件
		element.bind({
			focus : function() {
				eleLabel.css("color", "#CCCCCC");
			},
			blur : function() {
				if (this.value === "") {
					eleLabel.text(default_txt);
					eleLabel.css("color", "#8B9096");
				}
			},
			keydown : function() {
				eleLabel.text("");

			},
			keyup : function() {

				if (this.value === "") {
					eleLabel.text(default_txt);
					eleLabel.css("color", "#cccccc");
				} else {
					eleLabel.text("");
				}
			}
		});

	};

	//样式初始化
	if (element.val() === "") {
		eleLabel.text(default_txt);
	}
};
//创建banner导航按钮
//element 导航对象
meg.ui.funCreateNav = function(element) {
	//创建label元素
	var eleUl = $("<ul></ul>");
	eleUl.addClass("navUl");
	element.after(eleUl);

	for (var i = 0; i < element.children().length; i++) {
		var eleLi = $("<li></li>");
		eleLi.attr("index",i+1);
		eleLi.appendTo(eleUl);
	}
};

meg.app = {};

meg.app.funToTip = function() {
	var oChildText = $("#childText");
	var oParentText = $("#parentText");
	var oPwdText = $("#pwdText");

	meg.ui.funPlaceholder(oChildText);
	meg.ui.funPlaceholder(oParentText);
	meg.ui.funPlaceholder(oPwdText);
};
meg.app.funToBanner = function(oBanner) {
	meg.ui.funCreateNav(oBanner);
	var t = n = count = 0;
	count = $("#banner li").length;
	$("#banner li:not(:first-child)").hide();

	$(".navUl li").click(function() {
		var i = $(this).attr("index") - 1;
		//获取Li元素内的值，即1，2，3，4
		if (n == i) {
			return;
		} else {
			n = i;
		}

		if (i >= count)
			return;
		$("#banner li").filter(":visible").fadeOut(1000).parent().children().eq(i).fadeIn(1000);
		$(this).css({
			"background" : "#359ee5",
			'color' : '#ffffff'
		}).siblings().css({
			"background" : "#ffffff",
			'color' : '#359ee5'
		});
	});
	t = setInterval("meg.app.showAuto(count,n)", 5000);
	$(".navUl li").mouseenter(function() {
		clearInterval(t);
	});

	$(".navUl li").mouseout(function() {
		t = setInterval("meg.app.showAuto(count,n)", 3000);
	});
	$("#banner img").mouseenter(function() {
		clearInterval(t);
	});

	$("#banner img").mouseout(function() {
		t = setInterval("meg.app.showAuto(count,n)", 3000);
	});
};
meg.app.showAuto = function(count, n) {

	n = n >= (count - 1) ? 0 : ++n;
	$(".navUl li").eq(n).trigger('click');
};

$(function() {
	meg.app.funToTip();
	meg.app.funToBanner($("#banner"));
});
