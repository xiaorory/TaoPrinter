
function computeWidth() {

    var bw, sw;
    var bodyWidth, sidebarWidth;
	var sidebarObj = document.getElementById("sidebar");
	
	if(document.all)//���ΪIE�����
	{
	    bodyWidth = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
	    sw = sidebarObj.currentStyle.width;
	    sidebarWidth = sw.substr(0, sw.length - 2);
	    alert("aaa   " + bodyWidth);
	    alert(sidebarWidth);
	}else if(window.getComputedStyle)//���ΪFF�������������
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
