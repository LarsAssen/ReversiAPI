const apiUrl = 'test/url';

const Game = (function(url){
    //Level 2 opdracht 1
    console.log('hallo, vanuit een module')

    //Level 2 opdracht 2
    const privateInit = function(){
        console.log(configMap.api);
    }

    let configMap = {
        api: url,
    }
return {
    init: privateInit
}
})(apiUrl);

Game.Reversi = (function(){
    console.log('hallo, vanuit module Reversi')

    let configMap = {

    }

    const privateInit = function(){
        console.log('private');
    }

    return{
        init: privateInit
    }
})()