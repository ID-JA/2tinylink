import Image from 'next/image'

const Feature = ({
  title,
  description,
  src = '/icons/customizable.svg',
  released,
}: {
  title: string
  description: string
  src: string
  released: boolean
}) => {
  return (
    <div className="relative">
      <div className="flex justify-center items-center mb-4 w-10 h-10 rounded-full lg:h-12 lg:w-12">
        <Image alt={title} width={28} height={28} src={src} />
      </div>
      <h3 className="mb-2 text-xl font-bold">{title}</h3>
      <p className="text-gray-500">{description}</p>
      {!released ? (
        <div className="absolute top-0 right-0 bg-blue-100 text-sm text-blue-500 font-semibold px-2 rounded-full">
          coming soon
        </div>
      ) : null}
    </div>
  )
}
export default Feature
