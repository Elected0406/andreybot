var main = {
    init: function () {
        this.onSubmitBtn();      
    },
hitch: function(func){
       var caller = this;
        var calledArgs = [];
        for (var i=1; i<arguments.length; i++){
            calledArgs.push(arguments[i]);
        }
        return function(){
            var currArgs = [];
            for (var i=0; i<arguments.length; i++){
                currArgs.push(arguments[i]);
            }
            var args = calledArgs.concat(currArgs);
            caller[func].apply(caller, args);
        };
    },
    log: function(){
        console.log.apply(console, arguments);
    }, 
    event: function(node, eventName, n){
        node.addEventListener(eventName, n);
    },
    deevent: function(node, eventName, n){
        node.removeEventListener(eventName, n);
    },
    byId: function(id){
        return document.getElementById(id);
    },
    coords: function(node){
        var a = {};
        if (!node || !node.tagName)
            return a;
        var c = node.getBoundingClientRect();
        a.x = c.left;
        a.y = c.top;
        a.w = c.width;
        a.h = c.height;
        return a;
    },
    anim: function(obj){
        dojo.animateProperty(obj).play();
    },
     onSubmitBtn: function() {
        var btnElem = this.byId("sendmessage");
        this.event(btnElem, "click", this.hitch("scrollfixPos"));
    },
    scrollfixPos: function() {
      var elem = this.byId("div");
     var from = elem.scrollTop;
        var to = elem.scrollHeight;
        var hidden = this.byId("hiden");
        var _this = this;
        dojo.animateProperty({
            node: hidden,
            properties: {
                top: {
                    start: from,
                    end: to
                }
            },
            onAnimate: function(obj){
                var t = parseInt(obj.top.replace("px", ""), 10);
                elem.scrollTop = t;
            },
            onEnd: function() {
                console.log("ok");
            }
        }).play();
    }
};
