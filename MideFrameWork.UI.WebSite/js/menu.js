$(function(){
	
	$(".menu h3").click(function(){
		$(".menu li").removeClass("open_menu");
		$(this).parent().addClass("open_menu");
	});
	$(".menu_1 li") .mouseenter(function() {
   		$(this).addClass("hover");
	  }).mouseleave(function() {
		$(this).removeClass("hover");
	  });
	});
