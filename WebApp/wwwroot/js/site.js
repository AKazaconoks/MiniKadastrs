function initIndexPage() {
    $(document).ready(function () {
        loadTransactions();

        $("#uploadBtn").click(function () {
            var fileInput = $("#csvFile")[0];
            if (fileInput.files.length === 0) {
                alert("Please select a CSV file.");
                return;
            }

            var formData = new FormData();
            formData.append("file", fileInput.files[0]);

            $.ajax({
                url: "/PropertyTransaction/uploadcsv",
                data: formData,
                processData: false,
                contentType: false,
                type: "POST",
                success: function () {
                    alert("CSV file uploaded successfully.");
                    loadTransactions();
                },
                error: function () {
                    alert("An error occurred while uploading the CSV file.");
                }
            });
        });

        function loadTransactions() {
            $.ajax({
                url: "/PropertyTransaction",
                type: "GET",
                success: function (data) {
                    var tbody = $("#transactionsTable tbody");
                    tbody.empty();

                    $.each(data, function (_, transaction) {
                        var row = $("<tr></tr>");
                        row.append($("<td></td>").text(transaction.year));
                        row.append($("<td></td>").text(transaction.avgPriceRegion1));
                        row.append($("<td></td>").text(transaction.transactionCountRegion1));
                        row.append($("<td></td>").text(transaction.avgPriceRegion2));
                        row.append($("<td></td>").text(transaction.transactionCountRegion2));
                        row.append($("<td></td>").text(transaction.avgPriceRegion3));
                        row.append($("<td></td>").text(transaction.transactionCountRegion3));
                        tbody.append(row);
                    });
                },
                error: function () {
                    alert("An error occurred while loading property transactions.");
                }
            });
        }
    });
}

function initStatisticalPage(){
    var selectedRegion = 1;
    var transactions;
    var chart1, chart2;

    document.getElementById('region').addEventListener('change', function (event) {
        selectedRegion = parseInt(event.target.value);
        updateCharts();
    });

    fetch('https://localhost:44311/PropertyTransaction')
        .then(response => response.json())
        .then(data => {
            transactions = data;
            updateCharts();
        });

    function updateCharts() {
        var chart1Data = processDataForChart1(transactions, selectedRegion);
        var chart2Data = processDataForChart2(transactions, selectedRegion);
        if (!chart1) {
            chart1 = renderChart1(chart1Data);
        } else {
            updateChart(chart1, chart1Data);
        }
        if (!chart2) {
            chart2 = renderChart2(chart2Data);
        } else {
            updateChart(chart2, chart2Data);
        }
    }

    function processDataForChart1(transactions, region) {
        var labels = transactions.map(transaction => transaction.year);
        var avgPrice = transactions.map(transaction => transaction['avgPriceRegion' + region]);

        return {
            labels: labels,
            datasets: [{
                label: 'Average Price per Year',
                data: avgPrice,
                backgroundColor: "rgba(75, 192, 192, 0.2)",
                borderColor: "rgba(75, 192, 192, 1)",
                borderWidth: 1
            }]
        };
    }

    function processDataForChart2(transactions, region) {
        var labels = transactions.map(transaction => transaction.year);
        var transactionCount = transactions.map(transaction => transaction['transactionCountRegion' + region]);

        return {
            labels: labels,
            datasets: [{
                label: 'Number of Transactions per Year',
                data: transactionCount,
                backgroundColor: "rgba(153, 102, 255, 0.2)",
                borderColor: "rgba(153, 102, 255, 1)",
                borderWidth: 1,
                tension: 0.1
            }]
        };
    }

    function renderChart1(data) {
        var ctx = document.getElementById('chart1').getContext('2d');
        return new Chart(ctx, {
            type: 'bar',
            data: data,
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }

    function renderChart2(data) {
        var ctx = document.getElementById('chart2').getContext('2d');
        return new Chart(ctx, {
            type: 'line',
            data: data,
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }
    function updateChart(chart, data) {
        chart.data = data;
        chart.update();
    }
}