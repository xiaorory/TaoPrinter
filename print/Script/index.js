function clickMore()
{
	var getObj = document.getElementById("filter_detail");
	var display_value;
	if(document.all)//���ΪIE�����
    {
    	display_value = getObj.currentStyle.display;
	}else if(window.getComputedStyle)//���ΪFF�������������
	{
        display_value = window.getComputedStyle(getObj,null).getPropertyValue("display");
    }
	
	if(display_value == "none" )
	   document.getElementById("filter_detail").style.display="block";
	else if(display_value=="block")
	   document.getElementById("filter_detail").style.display ="none";
	
}
