import Image from "next/image";

import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Pagination, Autoplay } from "swiper/modules";

export default function CarrousselImage({Pictures}){

    return(

        <Swiper
      modules={[Navigation, Pagination, Autoplay]}
      Navigation={true}
      pagination={{ clickable: false }}
      autoplay={{ delay: 3000 }}
     loop={true}
      className="w-full h-130"
    >
      { Pictures.map((image => <SwiperSlide>
        <Image key= {image.imageId} src={image.url} alt="Image "  width={1920}
         height={100} className="w-full h-full object-cover" />
      </SwiperSlide>))}
      
    </Swiper>

    )
}