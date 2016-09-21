(function () {
    'use strict';

    angular
        .module('app')
        .controller('indexController', indexController);

    indexController.$inject = ['$location','$state','$rootScope','$scope']; 

    function indexController($location,$state, $rootScope, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'indexController';

        $rootScope.auth = null;

        $rootScope.CurrentBeer = true;

        $scope.logout = function () {
            $rootScope.auth = null;
            $state.go('home');
        }
    }
})();
