
"use client"; // très important pour Next.js 13+

import React, { useRef, useState } from 'react';
import { useEffect } from "react";
//import { Carousel, initTWE } from "tw-elements";
import Image  from "next/image";
import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css"; // styles de base
import "swiper/css/navigation"; // si navigation
import "swiper/css/pagination"; // si pagination
import { Navigation, Pagination, Autoplay } from "swiper/modules";
export default function Carroussel({Images}){

    

    return ( 

        <Swiper
      modules={[Navigation, Pagination, Autoplay]}
      
      pagination={{ clickable: false }}
      autoplay={{ delay: 3000 }}
     loop={true}
      className="w-full h-130"
    >
      { Images.map((image => <SwiperSlide>
        <Image key= {image.id} src={image.src} alt="Image "  width={1920}
         height={100} className="w-full h-full object-cover" />
      </SwiperSlide>))}
      
    </Swiper>

//         <div
//   id="carouselExampleSlidesOnly"
//   className="relative"
//   data-twe-carousel-init
//   data-twe-ride="carousel">
//   {/* <!--Carousel items--> */}
//   <div
//     className="relative w-full overflow-hidden after:clear-both after:block after:content-['']">
//     {/* <!--First item--> */}
//     <div
//       className="relative float-left -mr-[100%] w-full transition-transform duration-[600ms] ease-in-out motion-reduce:transition-none"
//       data-twe-carousel-item
//       data-twe-carousel-active>
//       <Image
//         src="/Images/im1.avif" alt="Image du Quebec "
//         width={1920}
//          height={100}
//          className="w-full block h-[300px] object-cover" />
//     </div>
//     {/* <!--Second item--> */}
//     <div
//       className="relative float-left -mr-[100%] hidden w-full transition-transform duration-[600ms] ease-in-out motion-reduce:transition-none"
//       data-twe-carousel-item>
//       <Image
//       src="/Images/im2.jpg" alt="Image du Quebec "
//         width={1920}
//          height={100}
//          className="w-full block h-[300px] object-cover"/>
//     </div>
//     {/* <!--Third item--> */}
//     <div
//       className="relative float-left -mr-[100%] hidden w-full transition-transform duration-[600ms] ease-in-out motion-reduce:transition-none"
//       data-twe-carousel-item>
//       <Image
//         src="/Images/im3.avif" alt="Image du Quebec "
//         width={1920}
//          height={100}
//          className="w-full block h-[300px] object-cover" />
//     </div>
//   </div>
// </div>
    );

}