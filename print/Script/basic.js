
function computeWidth() {

    var bw, sw;
    var bodyWidth, sidebarWidth;
	var sidebarObj = document.getElementById("sidebar");
	
	if(document.all)//如果为IE浏览器
	{
	    bodyWidth = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
	    sw = sidebarObj.currentStyle.width;
	    sidebarWidth = sw.substr(0, sw.length - 2);
	    alert("aaa   " + bodyWidth);
	    alert(sidebarWidth);
	}else if(window.getComputedStyle)//如果为FF或者其他浏览器
	{
	    var bodyObj = document.getElementById("body_content");
        bw = window.getComputedStyle(bodyObj,null).getPropertyValue("width");
        sw = window.getComputedStyle(sidebarObj, null).getPropertyValue("width"); 
        sidebarWidth = sw.substr(0, sw.length - 2);
        bodyWidth = bw.substr(0, bw.length - 2);
        alert("bbb   "+bodyWidth);
        alert(sidebarWidth);
    }

    var rw = (bodyWidth - sidebarWidth-17); alert(rw);
	document.getElementById("right_edit_ontent").style.width = rw+"px";
}
