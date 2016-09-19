(function () {
    'use strict';

    angular
        .module('app')
        .controller('loginController', loginController);

    loginController.$inject = ['$location', '$state', '$scope', '$rootScope', '$http'];

    function loginController($location, $state, $scope, $rootScope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'loginController';
        $scope.denied = false;


        $scope.login = function () {
            $http({
                    method: "POST",
                    url: "api/Authentification/Authentificate",
                    params: { username: $scope.username, password: $scope.password }
                })
                .success(function(response) {
                    $rootScope.auth = $scope.username;
                    $state.go('home');
                })
                .error(function(response) {
                    $scope.denied = true;
                });

        };
    }
})();
