var Jumbotron = function() {
    var indiceJumbotron = 0;
    var segundosTransicion = 3;
    var $jumbotron = $(".jumbotron");
    var imgJumbotron = [{
        "imgUri": "../img/hero-1.jpg"     
        },
        {
            "imgUri": "../img/hero-2.jpg"
        },
        {
            "imgUri": "../img/hero-3.jpg"
            
        }
    ];
    var caminar = function() {
        indiceJumbotron++;
        if (indiceJumbotron === 3) indiceJumbotron = 0;

        $($jumbotron).fadeOut("slow", function() {
         
            $(this).fadeIn();
            $jumbotron.css("background-image", "url(" + imgJumbotron[indiceJumbotron].imgUri + ")");
        });
        
    };
    var iniciar = function() {
        setInterval(caminar, segundosTransicion * 1000);
    };

    //* END:CORE HANDLERS *//

    return {
        init: function(segundos) {
            segundosTransicion = segundos;
            iniciar();
        }
    };
}();