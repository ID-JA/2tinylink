import { animated, useSpring } from '@react-spring/web'
import Image from 'next/image'
import { useState } from 'react'

import HomeLayout from '@/components/layout/home'
import Feature from './Feature'

const FEATURES = [
  {
    title: 'Customizable short links',
    description:
      'Create unique short links that reflect your brand or personality with our customizable options.',
    icon: '/icons/customizable.svg',
    released: false,
  },
  {
    title: 'Analytics tracking',
    description:
      'Get detailed analytics on clicks and user data to optimize your marketing efforts with our tracking feature.',
    icon: '/icons/analytics.svg',
    released: false,
  },
  {
    title: 'Link expiration',
    description:
      'Set a time limit on your short links so they automatically expire after a certain period with our link expiration option.',
    icon: '/icons/clock.svg',
    released: false,
  },
  {
    title: 'Password-protected links',
    description:
      'Create password-protected short links for private content or restricted access with our password protection feature.',
    icon: '/icons/protected.svg',
    released: false,
  },
  {
    title: 'QR code generator',
    description:
      'Generate QR codes for shortened links to allow for easy scanning and access using a smartphone or other device.',
    icon: '/icons/qr-code.svg',
    released: false,
  },
  {
    title: 'Social media integration',
    description:
      'Drive traffic to your content by integrating with popular social media platforms and easily sharing your short links with our social media integration feature.',
    icon: '/icons/global.svg',
    released: false,
  },
]
function Home() {
  const [open, toggle] = useState(false)

  const props = useSpring({
    from: { width: '66%' },
    to: { width: open ? '0%' : '66%', opacity: open ? 0 : 1 },
  })
  return (
    <HomeLayout>
      <section className="pt-28 px-10 max-w-[54rem] mb-20 mx-auto relative">
        <Image
          width={48}
          height={48}
          src="/left_sparkle.gif"
          alt="left_sparkle.gif"
          className="w-12 absolute bottom-[20%] left-0"
        />
        <Image
          width={48}
          height={48}
          src="/right_sparkle.gif"
          alt="right_sparkle.gif"
          className="w-12 absolute top-[20%] right-0"
        />
        <h1 className="text-3xl sm:text-4xl md:text-5xl xl:text-6xl text-neutral-800 font-extrabold text-center mb-6 md:leading-[60px] xl:leading-[70px]">
          Simplify Your Navigation with Short URLs
        </h1>
        <p className="mx-auto mb-6 text-lg font-normal text-center text-gray-700 md:text-xl md:max-w-lg">
          Shorten and manage your web links efficiently with our easy-to-use short URL app.
        </p>
        <form className="flex justify-center h-14">
          <animated.input
            aria-label="Paste your link here"
            placeholder="Paste your link here"
            style={props}
            type="url"
            className={`w-2/3 h-full  border-gray-900 border-2 rounded-l-md focus:outline-none ${
              open ? 'p-0 ' : 'px-4 '
            }`}
          />
          <animated.button
            type="submit"
            className={`px-6 text-white bg-black ${
              open ? 'rounded-md bg-opacity-50 cursor-not-allowed' : 'rounded-r-md'
            } focus:outline-none`}
            onClick={() => toggle(!open)}
          >
            {open ? (
              <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                <g fill="none" stroke="currentColor" strokeLinecap="round" strokeWidth="2">
                  <path
                    strokeDasharray="60"
                    strokeDashoffset="60"
                    strokeOpacity=".3"
                    d="M12 3C16.9706 3 21 7.02944 21 12C21 16.9706 16.9706 21 12 21C7.02944 21 3 16.9706 3 12C3 7.02944 7.02944 3 12 3Z"
                  >
                    <animate
                      fill="freeze"
                      attributeName="stroke-dashoffset"
                      dur="1.3s"
                      values="60;0"
                    />
                  </path>
                  <path
                    strokeDasharray="15"
                    strokeDashoffset="15"
                    d="M12 3C16.9706 3 21 7.02944 21 12"
                  >
                    <animate
                      fill="freeze"
                      attributeName="stroke-dashoffset"
                      dur="0.3s"
                      values="15;0"
                    />
                    <animateTransform
                      attributeName="transform"
                      dur="1.5s"
                      repeatCount="indefinite"
                      type="rotate"
                      values="0 12 12;360 12 12"
                    />
                  </path>
                </g>
              </svg>
            ) : (
              'Shorten'
            )}
          </animated.button>
        </form>
      </section>
      <section className="bg-white">
        <div className="py-8 px-4 mx-auto max-w-screen-xl sm:py-16 lg:px-6">
          <div className="max-w-screen-md mb-8 lg:mb-16">
            <h2 className="mb-4 text-4xl tracking-tight font-extrabold text-gray-900">
              All the features you need from a URL shortener
            </h2>
            <p className="text-gray-500 sm:text-xl">
              Shorten and manage your web links efficiently with our easy-to-use short URL app.
            </p>
          </div>
          <div className="space-y-8 md:grid md:grid-cols-2 lg:grid-cols-3 md:gap-12 md:space-y-0">
            {FEATURES.map((feature) => (
              <Feature
                key={feature.title}
                title={feature.title}
                description={feature.description}
                src={feature.icon}
                released={feature.released}
              />
            ))}
          </div>
        </div>
      </section>
    </HomeLayout>
  )
}

export default Home
