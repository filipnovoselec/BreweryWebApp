(function () {
    'use strict';

    angular
        .module('app')
        .controller('homepageController', homepageController);

    homepageController.$inject = ['$location', '$rootScope', '$scope'];

    function homepageController($location, $rootScope, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'homepageController';

       
    }
})();
