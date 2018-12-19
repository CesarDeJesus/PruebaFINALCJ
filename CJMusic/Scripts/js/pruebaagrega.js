if (localStorage.Contador == undefined) {
    localStorage.Contador = 0;
}

function myFunction() {


    localStorage.Contador = Number(localStorage.Contador) + 1;
    console.log(localStorage.Contador);
}

var morris1 = new Morris.Bar({
    // ID of the element in which to draw the chart.
    element: 'myfirstchart',
    // Chart data records -- each entry in this array corresponds to a point on
    // the chart.
    data: [
        { year: '2008', value: localStorage.Contador },
        { year: '2010', value: localStorage.Contador }
    ],
    // The name of the data record attribute that contains x-values.
    xkey: 'year',
    // A list of names of data record attributes that contain y-values.
    ykeys: ['value'],
    // Labels for the ykeys -- will be displayed when you hover over the
    // chart.
    labels: ['Value']
});

function myFunctions() {

    var nuevaData = [
        { year: '2008', value: localStorage.Contador },

    ];
    localStorage.clear();
    morris1.setData(nuevaData);
}