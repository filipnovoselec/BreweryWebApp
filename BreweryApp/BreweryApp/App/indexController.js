(function () {
    'use strict';

    angular
        .module('app')
        .controller('indexController', indexController);

    indexController.$inject = ['$location', '$state', '$rootScope', '$scope', '$http'];

    function indexController($location, $state, $rootScope, $scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'indexController';

        $rootScope.auth = null;

        //Provjera ima li pive u proizvodnji
        $http({
            method: "GET",
            url: "Beer/GetInfo"
        })
        .success(function (response) {
                console.log(response);
            $rootScope.CurrentBeer = response;
        });
        
        //Dohvacanje recepata
        $http({
            method: "GET",
            url: "api/Recipe/GetNames"
        })
        .success(function (response) {
            $scope.recipeList = response;
        });

        $scope.logout = function() {
            $rootScope.auth = null;
            $state.go('home');


        };
    }
})();
