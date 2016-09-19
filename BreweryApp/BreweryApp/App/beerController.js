(function () {
    'use strict';

    angular
        .module('app')
        .controller('beerController', beerController);

    beerController.$inject = ['$location']; 

    function beerController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'beerController';

        activate();

        function activate() { }
    }
})();
