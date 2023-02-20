import HomeLayout from '@/components/layout/home'

export default function Home() {
  return (
    <HomeLayout>
      <section className="pt-28 px-10 max-w-[54rem] mb-20 mx-auto relative">
        <img
          src="/left_sparkle.gif"
          alt="left_sparkle.gif"
          className="w-12 absolute top-[50%] left-0"
        />
        <img
          src="/right_sparkle.gif"
          alt="right_sparkle.gif"
          className="w-12 absolute top-[50%] right-0"
        />
        <h1 className="text-6xl text-neutral-800 font-extrabold text-center mb-6 leading-[70px]">
          Simplify Your Navigation with Short URLs
        </h1>
        <p className="text-gray-700 text-center text-xl font-normal mb-6">
          Shorten and manage your web links efficiently with our easy-to-use
          short URL app.
        </p>
        <form className="flex justify-center h-14">
          <input
            type="text"
            className=" h-full rounded-l-md px-4 border-2 border-blue-500 focus:outline-none w-2/3
              "
          />
          <button className="bg-blue-500 text-white px-6 rounded-r-md">
            Shorten
          </button>
        </form>
      </section>
    </HomeLayout>
  )
}
