// JavaScript Document

function show_without_shade(n01_title,n01_content){
	var n_left = ($(window).width() - $("#n01").width())/2;
	var n_top = ($(window).height() - $("#n01").height())/2;
	$("#n01").css({"left":n_left,"top":n_top})
	$("#n01_title").html(n01_title);
	$("#n01_content").html(n01_content);
	$("#n01").fadeIn(100);
	$("#n01").draggable();
}
function show_with_shade(){
	var z_div=$("<div id='z_div'></div>");
	z_div.css({"width":$(window).width(),"height":$(window).height(),"background-color":"#999","filter":"alpha(opacity=60)","opacity":0.6,"-moz-opacity":0.6,"position":"absolute","left":0,"top":0});
	$("body").append(z_div);
	$("#n01").css({"z-index":1002});
	$("#n01").fadeIn(800);
	$("#n01").draggable();
}
function close_f(){
$("#close_f").bind({
	click:function(){
		$("#z_div").remove();
		$("#n01").stop();
		$("#n01").fadeOut(100);
	}
});
}
$(document).ready(close_f);