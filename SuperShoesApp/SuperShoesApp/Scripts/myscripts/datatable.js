$(document).ready(function () {

    'use strict';

    var datatableInit = function () {

        $('#datatable-default').dataTable({
            "iDisplayLength": 50,
            language:
               {
                   "sProcessing": "Procesando...",
                   "sLengthMenu": "Mostrar _MENU_ registros",
                   "sZeroRecords": "No se encontraron resultados",
                   "sEmptyTable": "Ningún dato disponible en esta tabla",
                   "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                   "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                   "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                   "sInfoPostFix": "",
                   "sSearch": "",
                   "sUrl": "",
                   "sInfoThousands": ",",
                   "sLoadingRecords": "Cargando...",
                   "oPaginate": {
                       "sFirst": "Primero",
                       "sLast": "Último",
                       "sNext": "Siguiente",
                       "sPrevious": "Anterior"
                   },
                   "oAria": {
                       "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                       "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                   },
                   //search: '<span>Buscar:</span> _INPUT_',
                   lengthMenu: '<span>Mostrar:</span> _MENU_',
               },
            sDom: "<'text-right mb-md'T>" + $.fn.dataTable.defaults.sDom,
            oTableTools: {
                "sSwfPath": "/Content/vendor/jquery-datatables/extras/TableTools/swf/copy_csv_xls_pdf.swf",
                aButtons: [
                    {
                        sExtends: 'pdf',
                        sButtonText: 'PDF'
                    },
                    {
                        sExtends: 'csv',
                        sButtonText: 'CSV'
                    },
                    {
                        sExtends: 'xls',
                        sButtonText: 'Excel'
                    },
                    {
                        sExtends: 'print',
                        sButtonText: 'Imprimir',
                        sInfo: 'Please press CTR+P to print or ESC to quit'
                    }
                ]
            }
        });


        $('.dataTables_filter input[type=search]').attr('placeholder', 'Buscar...');

    };

    $(function () {
        datatableInit();

    });


}); // document.ready