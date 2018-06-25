using System;
using AutoMapper;
using Travco.HIS.Model.Request;
using Travco.HIS.Model.Request.DMG;

namespace Travco.HIS.Config
{
    public class AutoMapperConfig : Profile
    {
        public override string ProfileName => GetType().Name;

        public AutoMapperConfig()
        {
            // Map all XML objects to Search object

            //CreateMap<OTA_HotelAvailRQ, BOOKING>()
            //    .ForMember(dest => dest.lang, res => res.ResolveUsing(source =>
            //    {
            //        return source.PrimaryLangID;

            //    }));


            //CreateMap<OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentStayDateRange, DATE_DATA>()
            //    .ForMember(dest => dest.CHECK_IN_DATE, res => res.ResolveUsing(source =>
            //    {
            //        return "SHAJI";
            //    }))
            //    .ForMember(dest => dest.CHECK_OUT_DATE, res => res.ResolveUsing(source => source.End));


            //CreateMap<BOOKING, SearchAvailability>();
            //CreateMap<EnvelopeHeader, BOOKING>();

        //    CreateMap<SearchAvailability, BOOKING>()
        //        .ForMember(dest => dest.lang, res => res.ResolveUsing(source => source.Body.OTA_HotelAvailRQ.PrimaryLangID))
        //        .ForMember(dest => dest.DATA.DATE_DATA.CHECK_IN_DATE, res => res.ResolveUsing(source => source.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment.StayDateRange.Start));


        //    CreateMap<SearchAvailability, DATA>()
        //        .ForMember(dest => dest.DATE_DATA,
        //            res => res.ResolveUsing(source => source.Body.OTA_HotelAvailRQ.AvailRequestSegments
        //                .AvailRequestSegment.StayDateRange));

        }


    }
}