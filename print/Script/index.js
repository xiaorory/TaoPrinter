function clickMore()
{
	var getObj = document.getElementById("filter_detail");
	var display_value;
	if(document.all)//如果为IE浏览器
    {
    	display_value = getObj.currentStyle.display;
	}else if(window.getComputedStyle)//如果为FF或者其他浏览器
	{
        display_value = window.getComputedStyle(getObj,null).getPropertyValue("display");
    }
	
	if(display_value == "none" )
	   document.getElementById("filter_detail").style.display="block";
	else if(display_value=="block")
	   document.getElementById("filter_detail").style.display ="none";
	
}
