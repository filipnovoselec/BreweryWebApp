(function () {
    'use strict';

    angular
        .module('app')
        .controller('beerController', beerController);

    beerController.$inject = ['$location','$scope']; 

    function beerController($location, $scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'beerController';

        var clock = $('.clock').FlipClock(3600 * 24 * 3,{
            clockFace: 'DailyCounter',
            countdown: true,
            showSeconds: false
        });
    }
})();
