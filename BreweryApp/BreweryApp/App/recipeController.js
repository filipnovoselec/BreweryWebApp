(function () {
    'use strict';

    angular
        .module('app')
        .controller('recipeController', recipeController);

    recipeController.$inject = ['$location', '$stateParams', '$http','$scope'];

    function recipeController($location, $stateParams, $http, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'recipeController';
        var name = $stateParams.name;

        $http({
                method: "GET",
                url: "api/Recipe/GetRecipe",
                params: { name: name }
            })
            .success(function(response) {
                $scope.recipe = response;
            });


    }
})();
