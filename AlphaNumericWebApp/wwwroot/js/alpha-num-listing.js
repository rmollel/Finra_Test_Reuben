

//var testVar = phoneNumberList;
var app = angular.module('app', ['ngTouch', 'ui.grid', 'ui.grid.pagination']);

app.controller('MainCtrl', [
    '$scope', '$http', 'uiGridConstants', function ($scope, $http, uiGridConstants) {

        $scope.OriginalPhoneNumber = originalPhoneNumberInputVal;
        $scope.loading = true;

        var paginationOptions = {
            pageNumber: 1,
            pageSize: 25,
            sort: null
        };

        $scope.gridOptions = {
            paginationPageSizes: [100, 200, 300],
            paginationPageSize: 25,
            useExternalPagination: true,
            useExternalSorting: true,
            columnDefs: [
                { name: 'phone' }
            ],
           
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                    $scope.loading = true;
                    if (sortColumns.length == 0) {
                        paginationOptions.sort = null;
                    } else {
                        paginationOptions.sort = sortColumns[0].sort.direction;
                    }
                    getPage();
                    $scope.loading = false;
                });
                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    $scope.loading = true;
                    paginationOptions.pageNumber = newPage;
                    paginationOptions.pageSize = pageSize;
                    getPage();
                    $scope.loading = false;
                });
            }
        };

       

        //$http.get('/data/100.json').success(function (data) { $scope.myData = data; $scope.gridOptions.data = $scope.myData; });

        var getPage = function () {
            var absoluteUrl = window.location.origin + "/api/AlphaNum/Generate";
           
            

            $http({ method: 'POST', url: absoluteUrl, data: { "OriginalPhoneNumber": $scope.OriginalPhoneNumber} }).
                then(function (response) {
                    var data = response.data["data"].alphaNumbers;
                    $scope.gridOptions.totalItems = data.length;
                    var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
                    $scope.gridOptions.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);

                    $scope.loading = false;


                }, function (response) {
                    //Add logic to handle error here

                    $scope.loading = false;
                });



        };

        getPage();
    }
]);
