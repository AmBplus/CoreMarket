
function AddSrc() {
    var scriptElement = []
    var stringsrc = [];
    stringsrc.push("Jquery/lib/jquery/jquery.min.js");
    stringsrc.push("assets/js/bootstrap.min.js");
    stringsrc.push("assets/js/waves.js");
    stringsrc.push("assets/js/wow.min.js");
    stringsrc.push("assets/js/jquery.nicescroll.js");
    stringsrc.push("assets/js/jquery.scrollTo.min.js");
    stringsrc.push("assets/chat/moment-2.2.1.js");
    stringsrc.push("assets/jquery-sparkline/jquery.sparkline.min.js");
    stringsrc.push("assets/jquery-detectmobile/detect.js");
    stringsrc.push("assets/fastclick/fastclick.js");
    stringsrc.push("assets/jquery-slimscroll/jquery.slimscroll.js");
    stringsrc.push("assets/jquery-blockui/jquery.blockUI.js");
    stringsrc.push("assets/sweet-alert/sweet-alert.min.js");
    stringsrc.push("assets/sweet-alert/sweet-alert.init.js");
    stringsrc.push("assets/flot-chart/jquery.flot.js");
    stringsrc.push("assets/flot-chart/jquery.flot.time.js");
    stringsrc.push("assets/flot-chart/jquery.flot.tooltip.min.js");
    stringsrc.push("assets/flot-chart/jquery.flot.resize.js");
    stringsrc.push("assets/flot-chart/jquery.flot.pie.js");
    stringsrc.push("assets/flot-chart/jquery.flot.selection.js");
    stringsrc.push("assets/flot-chart/jquery.flot.stack.js");
    stringsrc.push("assets/flot-chart/jquery.flot.crosshair.js");
    stringsrc.push("assets/counterup/waypoints.min.js");
    stringsrc.push("assets/counterup/jquery.counterup.min.js");
    stringsrc.push("assets/js/jquery.app.js");
    stringsrc.push("assets/js/jquery.dashboard.js");
    stringsrc.push("assets/js/jquery.chat.js");
    stringsrc.push("assets/js/jquery.todo.js");
    for (var i = 0; i < stringsrc.length; i++) {
        scriptElement[i] = document.createElement('script');
        scriptElement[i].src = stringsrc[i];
        document.body.appendChild(scriptElement[i]);
    }
    

}
