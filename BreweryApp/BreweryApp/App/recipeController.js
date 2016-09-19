(function () {
    'use strict';

    angular
        .module('app')
        .controller('recipeController', recipeController);

    recipeController.$inject = ['$location']; 

    function recipeController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'recipeController';

        console.log($rootScope);
    }
})();
