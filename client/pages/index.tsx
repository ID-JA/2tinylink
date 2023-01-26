import HomeLayout from '@/components/layout/home'

export default function Home() {
  return (
    <HomeLayout>
      <main className="max-w-6xl mx-auto px-4 h-[calc(100vh_-_64px)] ">
        <div
          className="py-20 flex flex-col gap-4
        "
        >
          <div>
            <div className="mb-8">
              <h1
                className="text-4xl sm:text-6xl font-bold text-center  mb-4
            "
              >
                <span className="text-primary-500">2</span>tinylink
              </h1>
              <p className=" text-center  text-gray-500 max-w-lg mx-auto">
                2tinylink is a free URL shortener that allows you to create
                short and keep track of your links.
              </p>
            </div>
            <div className="relative max-w-2xl mx-auto">
              <input
                type="text"
                className="block w-full p-4 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 "
              />
              <button
                type="submit"
                className="text-white absolute right-2.5 bottom-2.5 bg-primary-500 hover:bg-primary-600 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-4 py-2 "
              >
                Shorten
              </button>
            </div>
          </div>
        </div>
      </main>
    </HomeLayout>
  )
}
