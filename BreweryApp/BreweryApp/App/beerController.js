(function () {
    'use strict';

    angular
        .module('app')
        .controller('beerController', beerController);

    beerController.$inject = ['$location', '$scope', '$http'];

    function beerController($location, $scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'beerController';

        var connection = $.hubConnection();
        var proxy = connection.createHubProxy('BeerHub');
        proxy.on('signalUpdate',
            function (response) {
                updateData();
            });
        connection.start();

        updateData();



        function updateData() {

            $http({
                method: "GET",
                url: "Beer/GetBeer"
            })
            .success(function (response) {
                $scope.Beer = response;

                var clock = $('.clock').FlipClock($scope.Beer.Time, {
                    clockFace: 'DailyCounter',
                    countdown: true,
                    showSeconds: false
                });

                $scope.percentage = (1 - $scope.Beer.Time / $scope.Beer.TotalTime) * 100;
                $scope.progress = { width: $scope.percentage + '%' };

                $scope.labels = $scope.Beer.ReadTime;
                $scope.series = ['Temperature'];
                $scope.data = [
                    $scope.Beer.Temperature];
                $scope.onClick = function (points, evt) {
                    console.log(points, evt);
                };
                $scope.datasetOverride = [{ yAxisID: 'y-axis-1' }];
                $scope.options = {
                    scales: {
                        yAxes: [
                          {
                              id: 'y-axis-1',
                              type: 'linear',
                              display: true,
                              position: 'left'
                          }

                        ]
                    }
                };
            });
        }





    }
})();
