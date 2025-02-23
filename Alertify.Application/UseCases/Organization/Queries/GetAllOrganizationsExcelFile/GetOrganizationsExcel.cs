using System.Data;
using Alertify.Application.Common;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.Organizations;
using AutoMapper;
using ClosedXML.Excel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.Organization.Queries.GetAllOrganizationsExcelFile
{
    public class GetOrganizationsExcel : IRequest<ExcelReportResponse>
    {
        public string FileName { get; set; }
    }

    public class GetOrganizationsExcelHandler : IRequestHandler<GetOrganizationsExcel, ExcelReportResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrganizationsExcelHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExcelReportResponse> Handle(GetOrganizationsExcel request, CancellationToken cancellationToken)
        {
            using (XLWorkbook workbook = new())
            {
                var orderData = await GetOrganizationsAsync(cancellationToken);
                var excelSheet = workbook.AddWorksheet(orderData, "Organizations");

                excelSheet.RowHeight = 20;
                excelSheet.Column(1).Width = 18;
                excelSheet.Column(2).Width = 18;
                excelSheet.Column(3).Width = 18;
                excelSheet.Column(4).Width = 18;
                excelSheet.Column(5).Width = 18;
                excelSheet.Column(6).Width = 18;
                excelSheet.Column(7).Width = 18;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);

                    return new ExcelReportResponse(memoryStream.ToArray(), "Organization/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{request.FileName}.xlsx");
                }
            }
        }

        private async Task<DataTable> GetOrganizationsAsync(CancellationToken cancellationToken = default)
        {
            var AllOrganizations = await _context.Organizations.ToListAsync(cancellationToken);

            DataTable excelDataTable = new()
            {
                TableName = "Empdata"
            };

            excelDataTable.Columns.Add("Здания", typeof(string));
            excelDataTable.Columns.Add("Подъезд №", typeof(int));
            excelDataTable.Columns.Add("Этаж", typeof(int));
            excelDataTable.Columns.Add("Квартира №", typeof(int));
            excelDataTable.Columns.Add("Количество комнат", typeof(int));
            excelDataTable.Columns.Add("Проектной площадью", typeof(decimal));
            excelDataTable.Columns.Add("Контракт №", typeof(string));

            var OrganizationsList = _mapper.Map<List<OrganizationResponse>>(AllOrganizations);

            if (OrganizationsList.Count > 0)
            {
                OrganizationsList.ForEach(item =>
                {
                    excelDataTable.Rows.Add(
                        item.ShortName,
                        item.FullName,
                        item.Inn,
                        item.PhoneNumber,
                        item.Address,
                        item.RegionId,
                        item.DistrictId,
                        item.OrganizationClassificationId,
                        item.Email); // Use ?. to handle nullable Contract.ContractNumber
                });
            }

            return excelDataTable;
        }
    }
}
