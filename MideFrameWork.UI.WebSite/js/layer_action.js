// JavaScript Document

//遮罩层函数
//调用：$(div).mask_layer('{"opacity":"","color":"","z_index":""}')
//参数说明：
//opacity：不透明度，数值型， 0 =< opacity =< 1 ，保留小数点后一位
//color:颜色，字符串，取值为 #xxxxxx ，或者#xxx ，或者 rgb(x,x,x) 格式
//z_index:整型
$.fn.mask_layer = function(json_param){
	var obj = $(this);
	var opacity,color,z_index;
	var parse_result = jQuery.parseJSON(json_param);
	if(parse_result == null){
		opacity = 0.5;
		color = "#000";
		z_index = "550";
	}else{
		opacity = parse_result.opacity;
		color = parse_result.color;
		z_index = parse_result.z_index;
	}
	obj.css({
		"position":"absolute",
		"left":"0",
		"top":"0",
		"z-index":z_index,
		"display":"block",
		"filter":"alpha(opacity="+ opacity +")",
		"-moz-opacity":opacity,
		"opacity":opacity,
		"width":$(document).width(),
		"height":$(document).height(),
		"background-color":color
	});	
}
/*
参数需要实现两个方法
getElement 用于获得需要拖动的元素
getDragBar 用于与获得拖动条
*/
var Drag = function(pop)
{
    var element = pop.getElement();
    var title = pop.getDragBar();
	var elementX,elementY, pointX, pointY;
	var currLeft , currTop;
	var self = this;
	var element_width = parseFloat(element.css("width"));
	var element_height = parseFloat(element.css("height"));
	var window_width = $(window).width();
	var window_height = $(window).height();
	var stop_x = window_width - element_width;
	var stop_y = window_height - element_height;
	this.onUp = function(){};
	
	this.getLeft = function(){return currLeft};
	this.getTop = function(){return currTop};
	
	var mouseDown = function(e)
	{
	     title.css('cursor','move');
		 $(document).bind('mousemove',mouseMove);
         $(document).bind('mouseup',mouseUp)		 
	     elementX = currLeft = parseFloat(element.css('left'));
         elementY = currTop = parseFloat(element.css('top'));
         pointX = e.pageX;
         pointY = e.pageY;		 
		 e.stopPropagation();
		 e.preventDefault();
	}
	
	var mouseMove = function(e)
	{
	    currLeft = elementX + e.pageX - pointX;
		currTop = elementY + e.pageY - pointY;
		if(currLeft < stop_x && currTop < stop_y){
			element.css('left',currLeft);
			element.css('top',currTop);
		}
		e.stopPropagation();
		e.preventDefault();
	}
	
	var mouseUp = function(e)
	{
	    title.css('cursor','default');
	    $(document).unbind('mousemove',mouseMove);
		$(document).unbind('mouseup',mouseUp);
		e.stopPropagation();
		e.preventDefault();
        if(typeof(self.onUp)=='function') self.onUp(self);		
	}
	
	this.bind = function()
	{
	   title.bind('mousedown',mouseDown);
	}
}

//弹出层函数
//调用：$(div).pop_layer('{"title":"","content":"","close_btn":"","close_icon":"","z_index":"","tip_icon":"ask"}')
//参数说明：
//title:标题，字符串
//content:内容，字符串
//close_btn:字符串，true/false ，弹出层下方的确定按钮
//close_icon:字符串，true/false ，弹出层上方的关闭按钮
//z_index:弹出层的z-index值 ，整型
//tip_icon:弹出层左边的图标，取值为right,err,info,ask
$.fn.pop_layer = function(json_param){	
	var obj = $(this);
	var obj_title,obj_content,z_index;
	var parse_result = jQuery.parseJSON(json_param);
	if(parse_result == null){
		obj_title = "提示";
		obj_content = "参数错误";
		z_index = 666;
	}else{
		obj_title = parse_result.title;
		obj_content = parse_result.content;
		z_index = parse_result.z_index;
	}
	if(parse_result.title == ""){
		obj_title = "提示";
	}
	if(parse_result.content == ""){
		obj_content = "参数错误";
	}
	if(parse_result.z_index == ""){
		z_index = 666;
	}
	$("#pop_layer_title").html(obj_title);
	$("#pop_layer_content").html(obj_content);
	var obj_left = ($(window).width() - obj.width())/2;
	var obj_top = ($(window).height() - obj.height())/2;
	obj.css({
		"display":"block",
		"position":"absolute",
		"left":obj_left,
		"top":obj_top,
		"z-index":z_index,
	});
	if(parse_result.close_btn == "true"){
		$("#pop_layer_close_btn").css({"display":"none"});
	}else{
		$("#pop_layer_close_btn").css({"display":"block"});
	}
	if(parse_result.close_icon == "true"){
		$("#pop_layer_close_icon").css({"display":"none"});
	}else{
		$("#pop_layer_close_icon").css({"display":"block"});
	}
	switch(parse_result.tip_icon){
		case "right":
			$(".pop_layer_content_left").css({"background-image":"url(images/right.gif)"});
		break;	
		case "info":
			$(".pop_layer_content_left").css({"background-image":"url(images/info.gif)"});
		break;	
		case "err":
			$(".pop_layer_content_left").css({"background-image":"url(images/err.gif)"});
		break;	
		case "ask":
			$(".pop_layer_content_left").css({"background-image":"url(images/ask.gif)"});
		break;
		case "wait":
			$(".pop_layer_content_left").css({"background-image":"url(images/loading.gif)"});
		break;
		default:
			$(".pop_layer_content_left").css({"background-image":"url(images/info.gif)"});
		break;	
	}
	var div = obj;
	var title = $(".pop_layer_title_wrap");
	var p = new Object;
	p.getElement = function(){return div;};
	p.getDragBar = function(){return title};
	var drag = new Drag(p);
	drag.bind();

}
//取消遮罩层、弹出层函数
//调用:mask_set_none(mask_id,pop_id)
//mask_id：遮罩层的ID
//pop_id：弹出层的ID
function mask_set_none(mask_id,pop_id){
	$("#pop_layer").css({"display":"none"});
	$("#mask_layer").css({"display":"none"});
}